using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.Networking;
public class cheak : MonoBehaviour
{
    int timeover = 10;
    [SerializeField]
    syokika syokika;
    public bool ok;
    string servername;
    public string guid,guid_local;

    public bool isSync;
    // Use this for initialization
    void Start()
    {
        ok = false;
        isSync = false;
        guid = "";
        StartCoroutine(GetText());
        servername = File.ReadAllText(Application.persistentDataPath+ "/menu/servername.txt");
        guid_local = File.ReadAllText(Application.persistentDataPath + "/menu/guid.txt");
    }

    public void reload()
    {
        guid_local = File.ReadAllText(Application.persistentDataPath + "/menu/guid.txt");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeover)
        {
            timeover = timeover + 5;

            StartCoroutine(GetText());
        }
    }

    IEnumerator GetText()
    {
        string servername = File.ReadAllText(Application.persistentDataPath + "/menu/servername.txt");
        UnityWebRequest request = UnityWebRequest.Get(servername + "/api/guid");

        yield return request.Send();

        // 通信エラーチェック
        if (request.isNetworkError)
        {
            Debug.Log(request.error);

        }
        else
        {
            if (request.responseCode == 200)
            {
                guid = request.downloadHandler.text;

                Debug.Log("local:" + guid_local + "net:" + guid + "is Up to date\n" + ok);

                if (guid_local != guid && ok && !isSync && guid != "")
                {
                    ok = false;
                    Debug.Log("これから初期化!W");
                    syokika.syokikaoff();
                }

        

            }
        }
    }

    public void setjson()
    {

    }

    public void checkstatus()
    {

    }
}