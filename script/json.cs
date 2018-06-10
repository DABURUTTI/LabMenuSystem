using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
using System.Net;
using System.Text;

public class json : MonoBehaviour {
    
    void Start()
    {
        readjson();
       
    }
    // Use this for initialization
    [SerializeField]
    Text menu1_name_set, menu1_price_set, menu1_comment_set,
            menu2_name_set, menu2_price_set, menu2_comment_set,
                 menu3_name_set, menu3_price_set, menu3_comment_set, comment1_set, comment2_set;
    [SerializeField]
    InputField menu1_name_get, menu1_price_get, menu1_comment_get,
            menu2_name_get, menu2_price_get, menu2_comment_get,
                 menu3_name_get, menu3_price_get, menu3_comment_get, comment1_get, comment2_get;
    Item menu;

    public bool Get_REST_API()
    {
        
        return true;
    }

    public bool Network_isActive()
    {
        return false;
    }

    public void readjson()
    {
        try
        {
            string menus = File.ReadAllText(Application.persistentDataPath+ "/menu/menus.json");
            
            menu = JsonUtility.FromJson<Item>(menus);
            Debug.Log("Menu load completed");
        }
        catch (System.Exception e)
        {
            Debug.Log("Jsonの読み込みに失敗しました >>>" + e);
            return;
        }

        settexts();
    }

    void settexts()
    {
        menu1_name_set.text = menu.menu1_name;
        menu1_price_set.text = menu.menu1_price;
        //menu1_comment_set.text = menu.menu1_comment;
        menu2_name_set.text = menu.menu2_name;
        menu2_price_set.text = menu.menu2_price;
        menu2_comment_set.text = menu.menu2_comment;
        menu3_name_set.text = menu.menu3_name;
        menu3_price_set.text = menu.menu3_price;
        menu3_comment_set.text = menu.menu3_comment;
        comment1_set.text = menu.comment1;
        /////////////////////////////////////////
        ////////////リソースインプット///////////
        /////////////////////////////////////////
        menu1_name_get.text = menu.menu1_name;
        menu1_price_get.text = menu.menu1_price;
        menu1_comment_get.text = menu.menu1_comment;
        menu2_name_get.text = menu.menu2_name;
        menu2_price_get.text = menu.menu2_price;
        menu2_comment_get.text = menu.menu2_comment;
        menu3_name_get.text = menu.menu3_name;
        menu3_price_get.text = menu.menu3_price;
        menu3_comment_get.text = menu.menu3_comment;
        comment1_get.text = menu.comment1;
        comment2_get.text = menu.comment2;
    }

    IEnumerator jsondo()
    {
        string a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p;

        j = menu1_comment_set.text.Replace("\n", "\\n");
        k = menu2_comment_set.text.Replace("\n", "\\n");
        l = menu3_comment_set.text.Replace("\n", "\\n");
        m = comment1_set.text.Replace("\n", "\\n");
        n = comment2_set.text.Replace("\n", "\\n");
        a = "{\"menu1_name\":\"" + menu1_name_set.text + "\"}";
        b = "{\"menu1_price\":\"" + menu1_price_set.text + "\"}";
        c = "{\"menu1_comment\":\"" + j + "\"}";
        d = "{\"menu2_name\":\"" + menu2_name_set.text + "\"}";
        e = "{\"menu2_price\":\"" + menu2_price_set.text + "\"}";
        f = "{\"menu2_comment\":\"" + k + "\"}";
        g = "{\"menu3_name\":\"" + menu3_name_set.text + "\"}";
        h = "{\"menu3_price\":\"" + menu3_price_set.text + "\"}";
        i = "{\"menu3_comment\":\"" + l + "\"}";
        o = "{\"comment1\":\"" + m + "\"}";
        p = "{\"comment2\":\"" + n + "\"}";


        JsonUtility.FromJsonOverwrite(a, menu);
        JsonUtility.FromJsonOverwrite(b, menu);
        JsonUtility.FromJsonOverwrite(c, menu);
        JsonUtility.FromJsonOverwrite(d, menu);
        JsonUtility.FromJsonOverwrite(e, menu);
        JsonUtility.FromJsonOverwrite(f, menu);
        JsonUtility.FromJsonOverwrite(g, menu);
        JsonUtility.FromJsonOverwrite(h, menu);
        JsonUtility.FromJsonOverwrite(i, menu);
        JsonUtility.FromJsonOverwrite(o, menu);
        JsonUtility.FromJsonOverwrite(p, menu);
        Debug.Log(menu);
        string updatedJson = JsonUtility.ToJson(menu);
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/menu/menus.json", false, Encoding.GetEncoding("UTF-8"));
        sw.Write(updatedJson);
        sw.Close();
        Debug.Log("done");

        yield return null;
    }

     public void writejson()
    {
        StartCoroutine(jsondo());
    }

    [System.Serializable]
    public class Item
    {
        public string menu1_name;
        public string menu1_price;
        public string menu1_comment;
        public string menu2_name;
        public string menu2_price;
        public string menu2_comment;
        public string menu3_name;
        public string menu3_price;
        public string menu3_comment;
        public string comment1;
        public string comment2;
    }

}
