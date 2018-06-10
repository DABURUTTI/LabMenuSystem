using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using System;

public class upload : MonoBehaviour {
    string servername;
    int progress = 0;
    [SerializeField]
    cheak chk;
    [SerializeField]
    Text prog;
    [SerializeField]
    Text sentfor;
    [SerializeField]
    Image img;
    [SerializeField]
    Animator UI; 
    [SerializeField]
    Text title;
    [SerializeField]
    Toggle tog;
    [SerializeField]
    Image bg;
    [SerializeField]
    GameObject game;
    [SerializeField]
    textfade fade;
    private void setvalu(int pro)
    {
        prog.text = pro.ToString() + "%";
        img.fillAmount = pro * 0.01F;
    }

    public void Startupload()
    {
        fade.stop = true;
        UI.SetBool("isOn", true);
        tog.isOn = true;
        bg.raycastTarget = true;

    }

    public void Stopupload()
    {
        fade.stop = false;
        bg.raycastTarget = false;
        UI.SetBool("isOn", false);
        tog.isOn = false;
    }

    public void Uploadnow()
    {
        iTween.MoveTo(game, iTween.Hash("x", -20, "time", 1, "EaseType", iTween.EaseType.easeInOutQuart, "islocal", true));
        chk.isSync = true;
        setvalu(0);
        servername = File.ReadAllText(Application.persistentDataPath+ "/menu/servername.txt");
        title.text = "ファイルをアップロードしています";
        sentfor.text = "接続先:　" + servername + "/api/post";
        StartCoroutine(Coroutine2());
    }


    IEnumerator Coroutine2()
    {
        yield return new WaitForSeconds(2);

        yield return StartCoroutine(UploadFile("menuimage1.png", "image/png"));
        Debug.Log("Upload:1");
        setvalu(20);
        yield return StartCoroutine(UploadFile("menuimage2.png", "image/png"));
        Debug.Log("Upload:2");
        setvalu(40);
        yield return StartCoroutine(UploadFile("menuimage3.png", "image/png"));
        Debug.Log("Upload:3");
        setvalu(60);
        yield return StartCoroutine(UploadFile("menus.json", "multipart/form-data"));
        Debug.Log("Upload:4");
        setvalu(80);
        yield return StartCoroutine(UpdateGuid("guid.txt", "multipart/form-data"));
        Debug.Log("Upload:5");
        setvalu(100);

    }


    IEnumerator UploadFile(string fileName, string type)
    {

        string filePath = Application.persistentDataPath + "/menu/" + fileName;
        // 画像ファイルをbyte配列に格納
        byte[] data = File.ReadAllBytes(filePath);

        // formにバイナリデータを追加
        WWWForm form = new WWWForm();
        form.AddBinaryData("file", data, fileName, type);
        // HTTPリクエストを送る
        UnityWebRequest request = UnityWebRequest.Post(servername + "/api/post", form);
        yield return request.Send();

        if (request.isNetworkError)
        {
            // POSTに失敗した場合，エラーログを出力
            Debug.Log(request.error);
        }
        else
        {
            // POSTに成功した場合，レスポンスコードを出力
            Debug.Log(request.responseCode);
            
        }
        yield return null;
    }


    IEnumerator UpdateGuid(string fileName, string type)
    {

        string filePath = Application.persistentDataPath + "/menu/" + fileName;
        string guidValue = Guid.NewGuid().ToString();

        byte[] data = System.Text.Encoding.GetEncoding(65001).GetBytes(guidValue);
        File.WriteAllBytes(filePath, data);

        chk.guid_local = guidValue;

        // 画像ファイルをbyte配列に格納
        byte[] data_ = File.ReadAllBytes(filePath);

        // formにバイナリデータを追加
        WWWForm form = new WWWForm();
        form.AddBinaryData("file", data_, fileName, type);
        // HTTPリクエストを送る
        UnityWebRequest request = UnityWebRequest.Post(servername + "/api/post", form);
        yield return request.Send();
        
        if (request.isNetworkError)
        {
            // POSTに失敗した場合，エラーログを出力
            Debug.Log(request.error);
        }
        else
        {
            // POSTに成功した場合，レスポンスコードを出力
            Debug.Log(request.responseCode.ToString() + chk.isSync.ToString());
            chk.isSync = false;
        }

        title.text = "アップロードが完了しました！";
        Invoke("uploadend", 2);
        yield return null;
    }


    public void uploadend()
    {
        bg.raycastTarget = false;
        UI.SetBool("isOn", false);
        tog.isOn = false;
        Invoke("back", 1);
        fade.stop = false;

    }

    public void back()
    {
        iTween.MoveTo(game, iTween.Hash("x", -0, "time", 1, "EaseType", iTween.EaseType.easeInOutQuart));
    }

}

