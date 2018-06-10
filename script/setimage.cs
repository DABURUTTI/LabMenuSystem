using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.Video;
using UnityEngine;
using UnityEngine.UI;

public class setimage : MonoBehaviour {
    [SerializeField]
    Text tex;
    float height = 0, width = 0, end = 0,end2 = 2, dis = 0, dib = 0, sizex,sizey,math;
    string tatenaga;
    // Use this for initialization
    void Start () {
        if (System.IO.File.Exists(Application.persistentDataPath+ "/menu/img.png"))
        {
            RawImage rawImage = this.GetComponent<RawImage>();
            getimgsize();
            sizex = this.GetComponent<RectTransform>().sizeDelta.x;
            sizey = this.GetComponent<RectTransform>().sizeDelta.y;


            math = sizey / sizex;
                        
            
            end = height / width;
            end2 = width / height;
            dis = sizex * end;
            dib = sizey * end2;

            if (math <= end)
            {
                tatenaga = "縦長";
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(sizex, dis);
            }
            else
            {
                tatenaga = "横長";
                this.GetComponent<RectTransform>().sizeDelta = new Vector2(dib, sizey);
            }
            Debug.Log("Image aspect scale calcluted!:" + end);
            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/menu/img.png");
            Texture2D texture = new Texture2D((int)width, (int)height);
            texture.filterMode = FilterMode.Point;
            texture.LoadImage(bytes);
            rawImage.texture = texture;
        }
        
        else
        {
            return;
        }
        setmenuimage1();
        setmenuimage2();
        setmenuimage3();
    }

    

    public void getimgsize()
    {
        byte[] readBinary = File.ReadAllBytes(Application.persistentDataPath + "/menu/img.png");
        int pos = 16;

        for (int i = 0; i < 4; i++)
        {
            width = width * 256 + readBinary[pos++];
        }


        for (int i = 0; i < 4; i++)
        {
            height = height * 256 + readBinary[pos++];
        }
    }
    public RawImage raw1, raw2, raw3;
    void setmenuimage1()
    {
        try
        {
            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/menu/menuimage1.png");
            Texture2D texture = new Texture2D(1920, 1080);
            texture.filterMode = FilterMode.Point;
            texture.LoadImage(bytes);
            raw1.texture = texture;
        }
        catch
        {
            raw1.texture = null;
        }
    }
    void setmenuimage2()
    {
        try
        {
            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/menu/menuimage2.png");
            Texture2D texture = new Texture2D(1920, 1080);
            texture.filterMode = FilterMode.Point;
            texture.LoadImage(bytes);
            raw2.texture = texture;
        }
        catch
        {
            raw2.texture = null;
            Debug.Log("s");
        }
    }
    void setmenuimage3()
    {
        try
        {
            byte[] bytes = File.ReadAllBytes(Application.persistentDataPath + "/menu/menuimage3.png");
            Texture2D texture = new Texture2D(1920, 1080);
            texture.filterMode = FilterMode.Point;
            texture.LoadImage(bytes);
            raw3.texture = texture;
        }
        catch
        {
            raw3.texture = null;
        }
    }
}
