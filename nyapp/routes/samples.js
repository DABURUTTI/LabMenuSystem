var express = require('express');
var router = express.Router();

/* サンプルAPI① 
 * http://localhost:3000/samples にGETメソッドのリクエストを投げると、
 * JSON形式で文字列を返す。
 */
router.get('/', function(req, res, next) {
    var param = { "値": "これはサンプルAPIです" };
    res.header('Content-Type', 'application/json; charset=utf-8')
    res.send(param);
});

/* サンプルAPI② 
 * http://localhost:3000/samples/hello にGETメソッドのリクエストを投げると、
 * JSON形式で文字列を返す。
 */
router.get('/hello', function(req, res, next) {
    var param = { "result": "Hello World !" };
    res.header('Content-Type', 'application/json; charset=utf-8')
    res.send(param);
});

router.get('/hello/:place', function(req, res, next) {
    // var param = {"result":"Hello "+ req.params.place + " !"};                          // ← ★★ 削除 ★★
    var param = { "result": "Hello " + req.params.place + " !", "shop name": req.query.shop }; // ← ★★ 追加 ★★
    res.header('Content-Type', 'application/json; charset=utf-8')
    res.send(param);
});

router.post('/', function(req, res, next) {
    var param = { "値": "POSTメソッドのリクエストを受け付けました", "bodyの値": req.body.card };
    res.header('Content-Type', 'application/json; charset=utf-8')
    res.send(param);
});

module.exports = router;