using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dit2 : MonoBehaviour {

    [SerializeField]
    InputField inp;
    // Use this for initialization
    public void EndEdit()
    {
        inp.text = "";
    }
}
