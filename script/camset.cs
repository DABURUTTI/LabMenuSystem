using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class camset : MonoBehaviour {
    public cam cams;

	// Use this for initialization

   public void set1()
    {
        cams.camset1();
        Debug.Log("Stop");
    }

    public void set2()
    {
        cams.camset2();
        Debug.Log("restart");
    }
   
}
