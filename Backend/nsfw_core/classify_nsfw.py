#!/usr/bin/env python
import numpy as np
import os
import sys
import argparse
import glob
import time
from PIL import Image
from StringIO import StringIO
import caffe


def resize_image(data, sz=(256, 256)):
    img_data = str(data)
    im = Image.open(StringIO(img_data))
    if im.mode != "RGB":
        im = im.convert('RGB')
    imr = im.resize(sz, resample=Image.BILINEAR)
    fh_im = StringIO()
    imr.save(fh_im, format='JPEG')
    fh_im.seek(0)
    return bytearray(fh_im.read())

def caffe_preprocess_and_compute(pimg, caffe_transformer=None, caffe_net=None, output_layers=None):
    if caffe_net is not None:
        if output_layers is None:
            output_layers = caffe_net.outputs

        img_data_rs = resize_image(pimg, sz=(256, 256))
        image = caffe.io.load_image(StringIO(img_data_rs))

        H, W, _ = image.shape
        _, _, h, w = caffe_net.blobs['data'].data.shape
        h_off = max((H - h) / 2, 0)
        w_off = max((W - w) / 2, 0)
        crop = image[h_off:h_off + h, w_off:w_off + w, :]
        transformed_image = caffe_transformer.preprocess('data', crop)
        transformed_image.shape = (1,) + transformed_image.shape

        input_name = caffe_net.inputs[0]
        all_outputs = caffe_net.forward_all(blobs=output_layers, **{input_name: transformed_image})

        outputs = all_outputs[output_layers[0]][0].astype(float)
        return outputs
    else:
        return []


def main(argv):
    pycaffe_dir = os.path.dirname(__file__)
    parser = argparse.ArgumentParser()
    parser.add_argument(
        "input_file",
        help="Path to the input image file"
    )
    parser.add_argument(
        "--model_def",
        help="Model definition file."
    )
    parser.add_argument(
        "--pretrained_model",
        help="Trained model weights file."
    )

    args = parser.parse_args()
    image_data = open(args.input_file).read()
    nsfw_net = caffe.Net(args.model_def, args.pretrained_model, caffe.TEST)
    caffe_transformer = caffe.io.Transformer({'data': nsfw_net.blobs['data'].data.shape})
    caffe_transformer.set_transpose('data', (2, 0, 1))
    caffe_transformer.set_mean('data', np.array([104, 117, 123]))
    caffe_transformer.set_raw_scale('data', 255)
    caffe_transformer.set_channel_swap('data', (2, 1, 0))
    scores = caffe_preprocess_and_compute(image_data, caffe_transformer=caffe_transformer, caffe_net=nsfw_net, output_layers=['prob'])
    print scores[1]

if __name__ == '__main__':
    main(sys.argv)
