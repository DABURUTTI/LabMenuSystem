using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;

public class MenuContloll : MonoBehaviour {
    [SerializeField]
    float Dpoint = 0F;
    float Xpoint = 0F;
    [SerializeField]
    int menusta = 3;
    Vector2 set;
    Vector2 set2 = new Vector2(-327F, 197.2F);
    [SerializeField]
    Toggle tog;


    public float timeOut = 5;
    
    public int menust = 0;

    

    private float timeTrigger = 5;
    public bool ismove = false;
    public GameObject menupoint,line;

    void Update() {
        if (Time.time > timeTrigger)
        {   //指定された時間ごとにトリガー発生
            if (ismove || tog.isOn == false)
            {
                setpoint();
            }
            timeTrigger = Time.time + timeOut;
        }
        //リープで補間計算＆設定
        menupoint.GetComponent<RectTransform>().localPosition = Vector2.Lerp(menupoint.GetComponent<RectTransform>().localPosition, set, 6 * Time.deltaTime);
        line.GetComponent<RectTransform>().localPosition = Vector2.Lerp(line.GetComponent<RectTransform>().localPosition, set2, 6 * Time.deltaTime);
    }

    

    public void setpoint()
    {
        menusta++;
        //設定の値を+1
        if (menusta % 4 == 0)
        {
            Xpoint = -327F;
            Dpoint = 0;
        }

        if (menusta % 4 == 1)
        {
            Xpoint = -195.3F;
            Dpoint = -800;
        }

        if (menusta % 4 == 2)
        {
            Xpoint = -64.5F;
            Dpoint = -1600;
        }

        if (menusta % 4 == 3)
        {
            Xpoint = 68F;
            Dpoint = -2400;
            
        }
        //目標座標セット
        set = new Vector2(Dpoint, 0);
        set2 = new Vector2(Xpoint, 197.2F);
    }

    

   

    public void setpoint_now()
    {
        if (menust == 0)
        {
            Xpoint = -327F;
            Dpoint = 0;
        }

        if (menust == 1)
        {
            Xpoint = -195.3F;
            Dpoint = -800;
        }

        if (menust ==  2)
        {
            Xpoint = -64.5F;
            Dpoint = -1600;
        }

        if (menust == 3)
        {
            Xpoint = 68F;
            Dpoint = -2400;
           
        }
        //目標座標セット
        set = new Vector2(Dpoint, 0);
        set2 = new Vector2(Xpoint, 197.2F);
    }

    
}
