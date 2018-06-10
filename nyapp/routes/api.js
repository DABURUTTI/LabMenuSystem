var express = require('express');
var router = express.Router();
var app = express();
var fs = require('fs');
var cors = require('cors');
var uuid = require('node-uuid');
var Jimp = require("jimp2");

var guid = '';
router.use(cors());
fs.readFile('./resouce/guid.txt', 'utf8', function (err, text) {
    guid = text;
});

// 追加 1
var multer = require('multer');
var storage = multer.diskStorage({
    // ファイルの保存先を指定
    destination: function (req, file, cb) {
        cb(null, '')
    },
    // ファイル名を指定(オリジナルのファイル名を指定)
    filename: function (req, file, cb) {
        if (file.fieldname == "file") {
            console.log(`SAVED as file`);
            cb(null, `./resouce/${file.originalname}`)
        }
        else {
            ext = file.originalname.split('.');
            console.log(`SAVED as ./resouce/${file.fieldname}.${ext[1]}`);

            cb(null, `./resouce/${file.fieldname}.png`)
        }
    },
})

router.get('/guid', function (req, res) {
    res.status(200).send(guid);

});

var upload = multer({ storage: storage })

router.get('/', function (req, res, next) {
    res.render('index', { title: 'Express' });
});

router.post('/post/json', function (req, res) {
    console.log(req.body);
    fs.writeFile('./resouce/menus.json', JSON.stringify(req.body, null, '    '));
    res.status(200).send(req.body);
});

router.post('/post', upload.any(), function (req, res) {
    if (req.files[0].originalname == `guid.txt`) {
        fs.readFile('./resouce/guid.txt', 'utf8', function (err, text) {
            guid = text;
        });
        res.json({ 'result': 'guid update!' });
        const spawn = require('child_process').spawn;
        const ls = spawn('ruby', ['/home/daburutti/ruby/kafeTweet.rb']);
    } else {
        console.log(req.files[0]);
        console.log("POST SUCCESS!");
        console.log(`./${req.files[0].path}`);
        if (req.files[0].filename.indexOf(".jpg") != -1 ||
                 req.files[0].filename.indexOf(".png") != -1 ||
                     req.files[0].filename.indexOf(".jpeg") != -1) {
            Jimp.read(`${req.files[0].path}`, function (err, lenna) {
                if (err) {
                    console.log(err);
                    throw err;
                    res.status(500).json({ 'result': 'Filed!' });
                }
                if (req.files[0].fieldname != "img") {
                    console.log(`${lenna.bitmap.width}x${lenna.bitmap.height}`)
                    var a = lenna.bitmap.width;
                    var b = lenna.bitmap.height;
                    if (a / b <= 16 / 9) {
                        var c = a * 9 / 16;
                        console.log(`pt1:${0},${((b - c) / 2)},${a},${c}`)
                        lenna.crop(0, (b - c) / 2, a, c)      // resize
                            .write(`./resouce/${req.files[0].fieldname}.png`); // save
                        console.log("Image Task Dane!");
                        lenna.resize(960, 540)            // resize
                            .quality(60).write(`./resouce/${req.files[0].fieldname}-sm.png`);
                        console.log("Sub Image Task Dane!");
                        res.json({ 'result': 'success!' });
                    }
                    else {
                        var c = b * 16 / 9;
                        console.log(`pt2:${a}${b}${c}:::${(a - c) / 2},${0},${b},${c}`)
                        lenna.crop(((a - c) / 2) - 1, 0, c, b)      // resize
                            .write(`./resouce/${req.files[0].fieldname}.png`); // save
                        console.log("Image Task Dane!");
                        lenna
                            .resize(960, 540)            // resize
                            .quality(60).write(`./resouce/${req.files[0].fieldname}-sm.png`);
                        console.log("Sub Image Task Dane!");
                        res.json({ 'result': 'success!' });

                    }
                }
                else {
                    console.log(`${lenna.bitmap.width}x${lenna.bitmap.height}`)
                    var a = lenna.bitmap.width;
                    var b = lenna.bitmap.height;
                    if (a / b <= 3840 / 1500) {
                        var c = a * 1500 / 3840;
                        console.log(`pt3:${0},${((b - c) / 2)},${a},${c}`)
                        lenna.crop(0, (b - c) / 2, a, c)      // resize
                            .write(`./resouce/${req.files[0].fieldname}.png`); // save
                        console.log("Image Task Dane!");
                        lenna.resize(1200, Jimp.AUTO)            // resize
                            .quality(60).write(`./resouce/${req.files[0].fieldname}-sm.png`);
                        console.log("Sub Image Task Dane!");
                        res.json({ 'result': 'success!' });
                    }
                    else {
                        var c = b * 3840 / 1500;
                        console.log(`pt4:${a}${b}${c}:::${(a - c) / 2},${0},${b},${c}`)
                        lenna.crop(((a - c) / 2) - 1, 0, c, b)      // resize
                            .write(`./resouce/${req.files[0].fieldname}.png`); // save
                        console.log("Image Task Dane!");
                        lenna
                            .resize(1200, Jimp.AUTO)            // resize
                            .quality(60).write(`./resouce/${req.files[0].fieldname}-sm.png`);
                        console.log("Sub Image Task Dane!");
                        res.json({ 'result': 'success!' });

                    }
                }


            });
        }
        else
        {
            res.status(500).json({ 'result': 'This is not Image file!' });
        }
    }
});

router.get('/img/:name?', function (req, res) {
    fs.readFile(`./resouce/${req.params.name}`, function (err, data) { //neko.jpgを読み込み、function(err,data)の呼び出し
        if (err) {
            res.status(404).send("そのようなファイルは存在しません");
        } else {
            res.set('Content-Type', 'image/png'); //ヘッダの指定 jpeg
            res.send(data); //送信
        }
    });
});

router.get('/guid/update', function (req, res) {
    guid = uuid.v1()
    fs.writeFile('./resouce/guid.txt', guid);
    res.status(200).send(guid);
}
);

router.get('/json/:name?', function (req, res) {
    fs.readFile(`./resouce/${req.params.name}`, function (err, data) { //neko.jpgを読み込み、function(err,data)の呼び出し
        if (err) {
            res.status(404).send("そのようなファイルは存在しません");
        } else {
            res.set('Content-Type', 'application/json'); //ヘッダの指定 jpeg
            res.send(data); //送信
        }
    });
});


module.exports = router;
