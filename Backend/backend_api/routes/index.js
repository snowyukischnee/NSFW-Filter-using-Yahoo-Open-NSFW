var express = require('express');
var router = express.Router();

const child_process = require('child_process');
const del = require('del')
const multer  = require('multer')
const storage = multer.diskStorage({
  destination: function (req, file, cb) {
    cb(null, 'uploads/')
  },
  filename: function (req, file, cb) {
    cb(null, file.originalname)
  }
});
const upload = multer({ storage: storage }).single('image');


router.post('/upload', 
  function (req, res, next) {
    upload(req, res, function(err) {
        if (err) {
          res.json({err: err});
        }
        if (!req.file) {
          res.json({err: "File not exists!"});
        } else {
          console.log(req.file.filename)
          let score = 1
          try {
            score = child_process.execSync(
              "python " + 
              "../nsfw_core/classify_nsfw.py " + 
              "--model_def ../nsfw_core/model/deploy.prototxt " + 
              "--pretrained_model ../nsfw_core/model/model.caffemodel " + 
              "uploads/" + req.file.filename
            );
            del.sync(["uploads/" + req.file.filename])
            res.json({score: score.toString().trim()});
          } catch (err) {
            res.json({err: "Error in execute caffe!"});
          }
        }
    });
  }
);


module.exports = router;

