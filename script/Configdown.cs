using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Configdown : MonoBehaviour {

    public cam cam;
    public json json;
    [SerializeField]
    Animator UI;
    [SerializeField]
    MenuContloll men;
    [SerializeField]
    textfade tex;
    [SerializeField]
    Toggle tog0;
    public void popdownConfig()
    {
        UI.SetBool("Config", false);
        tog0.isOn = false;
        tex.wait();

        Invoke("exit", 1);
    }

    public void exit()
    {
        cam.stopcam();
        json.writejson();
    }




}
