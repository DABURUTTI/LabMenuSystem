
window.onload = function getJson() {
    var xmlhttp = createXMLHttpRequest();
    var Jsonstr;
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4) {
            if (xmlhttp.status == 200) {
                var data = JSON.parse(xmlhttp.responseText);
                var elem = document.getElementById("inputname1");
                elem.value = data.menu1_name;
                var elem = document.getElementById("inputname2");
                elem.value = data.menu2_name;
                var elem = document.getElementById("inputname3");
                elem.value = data.menu3_name;
                var elem = document.getElementById("textArea1");
                elem.value = data.menu1_comment;
                var elem = document.getElementById("textArea2");
                elem.value = data.menu2_comment;
                var elem = document.getElementById("textArea3");
                elem.value = data.menu3_comment;
                var elem = document.getElementById("comment1");
                elem.value = data.comment1;
                var elem = document.getElementById("comment2");
                elem.value = data.comment2;
                var elem = document.getElementById("price1");
                elem.value = data.menu1_price;
                var elem = document.getElementById("price2");
                elem.value = data.menu2_price;
                var elem = document.getElementById("price3");
                elem.value = data.menu3_price;
                var elem = document.getElementById("textArea");
                elem.value = xmlhttp.responseText
            } else {
            }
        }
    }

    xmlhttp.open("GET", "http://122.210.136.164:443/api/json/menus.json");
    xmlhttp.send();
}
function createXMLHttpRequest() {
    if (window.XMLHttpRequest) { return new XMLHttpRequest() }
    if (window.ActiveXObject) {
        try { return new ActiveXObject("Msxml2.XMLHTTP.6.0") } catch (e) { }
        try { return new ActiveXObject("Msxml2.XMLHTTP.3.0") } catch (e) { }
        try { return new ActiveXObject("Microsoft.XMLHTTP") } catch (e) { }
    }
    return false;
}

function createJsondata() {
    Jsonstr = JSON.stringify({
        menu1_name: document.getElementById("inputname1").value,
        menu1_price: document.getElementById("price1").value,
        menu1_comment: document.getElementById("textArea1").value,

        menu2_name: document.getElementById("inputname2").value,
        menu2_price: document.getElementById("price2").value,
        menu2_comment: document.getElementById("textArea2").value,

        menu3_name: document.getElementById("inputname3").value,
        menu3_price: document.getElementById("price3").value,
        menu3_comment: document.getElementById("textArea3").value,

        comment1: document.getElementById("comment1").value,
        comment2: document.getElementById("comment2").value
    });
    var elem = document.getElementById("textArea");
    elem.value = Jsonstr;
}
function guidupdate() {
    var xmlhttp_guid = createXMLHttpRequest();
    xmlhttp_guid.open("GET", "http://www.dabudabu.net:443/api/guid/update");
    xmlhttp_guid.send();
}

function ExecUpload_1() {
    var formObj = document.getElementById("form1")
    var data = new FormData(formObj);

    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            guidupdate();
            SetDeDone();
            var elem = document.getElementById("test1");
            elem.innerHTML = "<span style='color: red;'>アップロード済み</span>"
            var elem = document.getElementById("image1");
            src = elem.src;
            src = src.replace(/\?.*$/, "");
            var url = src + '?' + (new Date()).getTime();
            elem.src = "./loading.gif";
            setTimeout(reloadimage.bind(this, url,"image1"), 3000);
        }
    };
    dialog_show();
    SetDefault();
    xmlhttp.open("POST", "http://www.dabudabu.net:443/api/post", true);
    xmlhttp.send(data);
}

function ExecUpload_2() {
    var formObj = document.getElementById("form2")
    var data = new FormData(formObj);
    SetDefault();
    dialog_show();
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            guidupdate();
            SetDeDone();

            var elem = document.getElementById("test2");
            elem.innerHTML = "<span style='color: red;'>アップロード済み</span>"
            var elem = document.getElementById("image2");
            src = elem.src;
            src = src.replace(/\?.*$/, "");
            var url = src + '?' + (new Date()).getTime();
            elem.src = "./loading.gif";
            setTimeout(reloadimage.bind(this, url,"image2"), 3000);
        }
    };
    xmlhttp.open("POST", "http://www.dabudabu.net:443/api/post", true);
    xmlhttp.send(data);
}
function ExecUpload_3() {
    var formObj = document.getElementById("form3")
    var data = new FormData(formObj);

    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        SetDefault();
        dialog_show();
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            guidupdate();
            SetDeDone();
            var elem = document.getElementById("test3");
            elem.innerHTML = "<span style='color: red;'>アップロード済み</span>"
            var elem = document.getElementById("image3");
            src = elem.src;
            src = src.replace(/\?.*$/, "");
            var url = src + '?' + (new Date()).getTime();
            elem.src = "./loading.gif";
            setTimeout(reloadimage.bind(this, url,"image3"), 3000);
        }
    };
    xmlhttp.open("POST", "http://www.dabudabu.net:443/api/post", true);
    xmlhttp.send(data);
}
function ExecUpload_4() {
    var formObj = document.getElementById("form4")
    var data = new FormData(formObj);
    SetDefault();
    dialog_show();
    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            guidupdate();
            SetDeDone();

            var elem = document.getElementById("test4");
            elem.innerHTML = "<span style='color: red;'>アップロード済み</span>"
            var elem = document.getElementById("image4");
            src = elem.src;
            src = src.replace(/\?.*$/, "");
            var url = src + '?' + (new Date()).getTime();
            elem.src = "./loading.gif";
            setTimeout(reloadimage.bind(this, url,"image4"), 3000);
        }
    };
    xmlhttp.open("POST", "http://www.dabudabu.net:443/api/post", true);
    xmlhttp.send(data);
}

function reloadimage(url,target) {
    var elem = document.getElementById(target);
    elem.src = url;
}
function SetDefault() {
    var elem = document.getElementById("dialogtext");
    elem.innerHTML = "<span><h5>データを処理しています<br>しばらくお待ちください</h5></span>"
    var elem = document.getElementById("dialoghead");
    elem.innerHTML = "サーバーが処理を行っています..."
    var elem = document.getElementById("progress");
    elem.style.display = "block";
}

function SetDeDone() {
    var elem = document.getElementById("dialogtext");
    elem.innerHTML = "<h4>データの更新が完了しました！</h4>"
    var elem = document.getElementById("dialoghead");
    elem.innerHTML = "完了！"
    var elem = document.getElementById("progress");
    elem.style.display = "none";
}


function ExecUpload_json() {
    var xmlhttp = new XMLHttpRequest();
    createJsondata();
    SetDefault();
    dialog_show();
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            SetDeDone();
            guidupdate();
        }
    };

    xmlhttp.open("POST", "http://www.dabudabu.net:443/api/post/json", true);
    xmlhttp.setRequestHeader('Content-Type', 'application/json');
    xmlhttp.send(Jsonstr);
}
function dialog_show() {
    jQuery(document).ready(function () {
        jQuery('.modal').modal('show');
    });


}

