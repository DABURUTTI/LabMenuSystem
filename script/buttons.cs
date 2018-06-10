using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttons : MonoBehaviour {
    [SerializeField]
    RawImage img1 = null, img2 = null, img3 = null;
    public void button1()
    {
        img1.texture = null;
    }

    public void button2()
    {
        img2.texture = null;
    }

    public void button3()
    {
        img3.texture = null;
    }
}
