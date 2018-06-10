using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class cam : MonoBehaviour {

    public int Width = 1920;
    public int Height = 1080;
    public int FPS = 1;
    public int camstatus = 2;
    public Color32[] img1;
    public Color32[] img2;
    public Color32[] img3;

    [SerializeField]
    RawImage campic,campic2;


    public WebCamTexture webcamTexture;
    void Start()
    {

    }

    [SerializeField]

    RawImage set1 = null,set2= null,set3 = null;
    
    public void camset1()
    {
        img1 = webcamTexture.GetPixels32();
        Texture2D texture = new Texture2D(webcamTexture.width, webcamTexture.height);
        texture.SetPixels32(img1);
        texture.Apply();
        set1.texture = texture;
        this.GetComponent<RawImage>().texture = texture;
        
        var bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.persistentDataPath + "/menu/menuimage1.png", bytes);
        
    }

    public void camset2()
    {
        img2 = webcamTexture.GetPixels32();
        Texture2D texture = new Texture2D(webcamTexture.width, webcamTexture.height);
        texture.SetPixels32(img2);
        texture.Apply();
        set2.texture = texture;
        campic.texture = texture;
        var bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.persistentDataPath + "/menu/menuimage2.png", bytes);
    }

    public void camset3()
    {
        img3 = webcamTexture.GetPixels32();
        Texture2D texture = new Texture2D(webcamTexture.width, webcamTexture.height);
        texture.SetPixels32(img3);
        texture.Apply();
        set3.texture = texture;
        campic2.texture = texture;
        var bytes = texture.EncodeToPNG();
        File.WriteAllBytes(Application.persistentDataPath + "/menu/menuimage3.png", bytes);
    }

    public void retry1()
    {
        this.GetComponent<RawImage>().texture = webcamTexture;
    }

    public void retry2()
    {
        campic.texture = webcamTexture;
    }
    public void retry3()
    {
        campic2.texture = webcamTexture;
    }

    public void startcam()
    {
        StartCoroutine(start());
    }

    public void stopcam()
    {
        StartCoroutine(stop());
    }

    private IEnumerator stop()
    {
        webcamTexture.Stop();
        yield return null;
    }
    private IEnumerator start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        // display all cameras

        for (var i = 0; i < devices.Length; i++)
        {
            Debug.Log(devices[i].name);
        }

        webcamTexture = new WebCamTexture(devices[camstatus].name, Width, Height, FPS);
        this.GetComponent<RawImage>().texture = webcamTexture;
        campic.texture = webcamTexture;
        campic2.texture = webcamTexture;
        webcamTexture.Play();

        yield return null;
    }

}
