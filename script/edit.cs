using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class edit : MonoBehaviour
{
    [SerializeField]
    Text text;
    [SerializeField]
    InputField inp;
    // Use this for initialization
    public void EndEdit()
    {
        inp.text = "";
    }
    public void settext()
    {
        text.text = this.GetComponent<Text>().text;
    }
}

