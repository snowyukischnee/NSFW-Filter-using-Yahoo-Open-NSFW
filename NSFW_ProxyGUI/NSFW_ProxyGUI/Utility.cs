using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSFW_ProxyGUI {
    class Utility {
        public static int? ParseNInt(string val) {
            int i;
            return int.TryParse(val, out i) ? (int?)i : null;
        }

        public static int ParseNInt(string val, int def) {
            int i;
            return int.TryParse(val, out i) ? (int)i : def;
        }

        public static byte[] ImgByteArr(Image x) {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }
    }
}
