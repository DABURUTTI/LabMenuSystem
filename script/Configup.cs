
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Configup : MonoBehaviour {
    [SerializeField]
    Animator UI;
    [SerializeField]
    cam cam;
    public void popupConfig()
    {
            UI.SetBool("Config", true);
        //カメラの呼び出しには時間がかかるので
        //Waitをしてアニメーションの再生が終わった時点で呼び出す。
        Invoke("doit", 0.5f);

    }
    void doit()
    {
        cam.startcam();
    }
}
