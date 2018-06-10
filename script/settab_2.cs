using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class settab_2 : MonoBehaviour
{
    [SerializeField]
    float Xpoint = 0F, Dpoint = -245.5F;
    [SerializeField]
    public int menust;
    Vector2 set2 = new Vector2(0, 0F);
    Vector2 set1 = new Vector2(-297.6F, 107.1F);
    [SerializeField]
 
    public GameObject line,obj;

    void Update()
    {
        //リープで補間計算＆設定
        line.GetComponent<RectTransform>().localPosition = Vector2.Lerp(line.GetComponent<RectTransform>().localPosition, set2,  10*Time.deltaTime);
        obj.GetComponent<RectTransform>().localPosition = Vector2.Lerp(obj.GetComponent<RectTransform>().localPosition, set1, 10 * Time.deltaTime);
    }


    public void setpoint_now()
    {
        if (menust == 0)
        {
            Xpoint = -0F;
            Dpoint = -297.6F;
        }

        if (menust == 1)
        {
            Xpoint = -800.5F;
            Dpoint = -153.3F;
        }

        if (menust == 2)
        {
            Xpoint = -1601F;
            Dpoint = -8.3F;
        }
        if (menust == 3)
        {
            Xpoint = -2402F;
            Dpoint = 310.9F;
        }
        //目標座標セット
        set2 = new Vector2(Xpoint,0F);
        set1 = new Vector2(Dpoint, 107.1F);
    }
}