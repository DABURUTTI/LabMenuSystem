using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moving : MonoBehaviour
{

    float y = 0;
    void Update()
    {
        this.GetComponent<RectTransform>().localPosition = new Vector3(0,0,y);

        y = y + 0.00000000001F;

        if(y >= 1)
        {
            y = 0;
        }
    }
}
