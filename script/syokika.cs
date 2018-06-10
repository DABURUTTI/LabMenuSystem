using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;
using System;
using System.Text;
public class syokika : MonoBehaviour {
    public Animator anim;
    [SerializeField]
    Text text, text_sub, textbox;
    [SerializeField]
    cheak ch;
    [SerializeField]
    GameObject button, button2;
    [SerializeField]
    Image bar,fill;

    public bool timeout_bool;
    public string servername = "";
    public string guid = "";
    float loading = 0;
    bool isDonload = false;
    string text0;
    int prog;
    class FileDownloadHandler : DownloadHandlerScript
    {
        FileStream fs;
        int offset = 0;
        int length = 0;

        int loading = 0;

        bool download = false;

        public FileDownloadHandler(string path, byte[] buffer)
            : base(buffer)
        {
            fs = new FileStream(path, FileMode.Create, FileAccess.Write);
        }

        // データを受信すると呼び出される
        protected override bool ReceiveData(byte[] data, int dataLength)
        {
            fs.Write(data, 0, dataLength);
            offset += dataLength;
            return true;
        }
        // ダウンロードが終わった時に呼び出される
        protected override void CompleteContent()
        {
            fs.Flush();
            fs.Close();
        }
        // ダウンロードするサイズ
        protected override void ReceiveContentLength(int contentLength)
        {
            length = contentLength;
        }
        // downloadProgressの値
        protected override float GetProgress()
        {
            if (length == 0)
                return 0.0f;

            return (float)offset / length;
        }
    }

    // Use this for initialization
    void Start () {
        prog = 0;
        timeout_bool = true;
        //text_sub.text = "接続先:" + servername + "/api";
        //text.text = "APIサーバーに接続しています";
        if (!File.Exists(Application.persistentDataPath+ "/menu/servername.txt") ||
            File.ReadAllText(Application.persistentDataPath + "/menu/servername.txt") == "" ||
            !File.Exists(Application.persistentDataPath + "/menu/guid.txt"))
        {
            if (!Directory.Exists(Application.persistentDataPath + "/menu/"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/menu/");

                string guidValue = Guid.NewGuid().ToString();

                byte[] data = System.Text.Encoding.GetEncoding(65001).GetBytes(guidValue);
                File.WriteAllBytes(Application.persistentDataPath + "/menu/guid.txt", data);

                byte[] data_2 = System.Text.Encoding.GetEncoding(65001).GetBytes("http://122.210.136.164:3000");
                File.WriteAllBytes(Application.persistentDataPath + "/menu/servername.txt", data_2);

                Debug.Log("noteexist");
            }
            else
            {
                if(!File.Exists(Application.persistentDataPath + "/menu/guid.txt"))
                {
                    string guidValue = Guid.NewGuid().ToString();
                    byte[] data = System.Text.Encoding.GetEncoding(65001).GetBytes(guidValue);
                    File.WriteAllBytes(Application.persistentDataPath + "/menu/guid.txt", data);
                }

                if (!File.Exists(Application.persistentDataPath + "/menu/servername.txt"))
                {
                    byte[] data_2 = System.Text.Encoding.GetEncoding(65001).GetBytes("http://122.210.136.164:3000");
                    File.WriteAllBytes(Application.persistentDataPath + "/menu/servername.txt", data_2);
                }
            }

        }
            text.text = "APIサーバーに接続しています";
            StartCoroutine(GetText());
            servername = File.ReadAllText(Application.persistentDataPath + "/menu/servername.txt");
            text_sub.text = "接続先:" + servername + "/api";
        Invoke("timeout", 5);
    }

    public void timeout()
    {
        if (timeout_bool)
        {
            changecolor();
            text.text = "接続がタイムアウトしました";
            text_sub.text = "サーバーがオフラインか、接続先が間違っています";
            StopCoroutine(GetText());
        }
    }

    public void fadetext()
    {
        text.text = "メニューを設定しています";
    }
    public void fadetext2()
    {
        text.text = "最新の情報に更新しています";
    }
    public void syokikaon()
    {
        anim.SetBool("syokika", true);
        ch.ok = true;
        Invoke("back", 3);
    }

    public void back()
    {
        fill.fillAmount = 0;
    }
    public void syokikaoff()
    {
        text.text = "メニューデータの更新をチェックしています";
        text_sub.text = "最新のメニューID:" + guid;
        anim.SetBool("syokika", false);
        Invoke("restart", 1);

    }
     public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetRestart()
    {
        text.text = "リスタートしています";
        text_sub.text = "しばらくお待ちください";
        string hexColor = "#ff9e49";
        Color color = default(Color);
        ColorUtility.TryParseHtmlString(hexColor, out color);
        bar.color = color;
        Invoke("restart", 1);

        Debug.Log("Restarting....:" + servername);
    }


    IEnumerator GetText()
    {
        string servername = File.ReadAllText(Application.persistentDataPath + "/menu/servername.txt");
        UnityWebRequest request = UnityWebRequest.Get(servername + "/api/guid");

        yield return request.Send();

        timeout_bool = false;

        guid = File.ReadAllText(Application.persistentDataPath + "/menu/guid.txt");
        // 通信エラーチェック
        if (request.isNetworkError)
        {
            text.text = "ネットワーク接続エラー";
            text_sub.text = "ネットワークが無効、またはサーバーがオフラインです";
            Debug.Log(request.error);
            changecolor();
        }
        else
        {
            if (request.responseCode == 200)
            {
                // UTF8文字列として取得する
                text0 = request.downloadHandler.text;

                // バイナリデータとして取得する

                if (text0 == guid)
                {
                    text.text = "Current data is up to date!";
                    text_sub.text = "更新完了";
                    textbox.text = "最新のメニューがロードされました\nメニューID:" +guid;
                    Invoke("syokikaon", 1);
                }
                else
                {
                    text.text = "最新のデータが見つかりました";
                    text_sub.text = "情報の更新を開始しています";
                    douki();
                }
            }
        }
    }
    private void setValue(int n)
    { 
        text_sub.text = n.ToString() + "%";
        fill.fillAmount = n * 0.01F;
    }

    public void douki()
    {
        prog = 0;
        StartCoroutine(Coroutine());
    }

    public void changecolor()
    {
        string hexColor = "#ff665b";
        Color color = default(Color);
        ColorUtility.TryParseHtmlString(hexColor, out color);
        bar.color = color;
        button.SetActive(true);
        button2.SetActive(true);
    }

    public void donextx()
    {

        Debug.Log("END CORU");
        text_sub.text = "更新完了";
        text.text = "最終処理を行っています";
        File.WriteAllText(Application.persistentDataPath + "/menu/guid.txt", text0, Encoding.UTF8);
        restart();
    }


    IEnumerator Coroutine()
    {
        Debug.Log("Download:1");
        yield return StartCoroutine(Download("/api/img/", "img.png"));

        setValue(20);

        Debug.Log("Download:2");
        yield return StartCoroutine(Download("/api/img/", "menuimage1.png")); ;
        setValue(40);
        Debug.Log("Download:3");
        yield return StartCoroutine(Download("/api/img/", "menuimage2.png")); ;
        setValue(60);
        Debug.Log("Download:4");
        yield return StartCoroutine(Download("/api/img/", "menuimage3.png")); ;
        setValue(80);
        Debug.Log("Download:5");
        yield return StartCoroutine(Download("/api/json/", "menus.json")); ;
        setValue(100);
        Debug.Log("DONE");

        donextx();
    }


    IEnumerator Download(string uri,string filename)
    {
        WWW www = new WWW(servername + uri + filename);

        while (!www.isDone) { }

        File.WriteAllBytes(Application.persistentDataPath + "/menu/"+ filename, www.bytes);
        yield return null;
    }

}
