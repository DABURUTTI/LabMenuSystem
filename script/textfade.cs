using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textfade : MonoBehaviour
{
    [SerializeField]
    public float waittime = 7, timeset = 7;

    [SerializeField]
    public Text text1, text2;

    public bool stop;
    float x;
    
    [SerializeField]
    int textsta = 0;

    [SerializeField]
    bool move = true, down, isactive = false;

    void Start () {
        Invoke("wait", 1);
        stop = false;
        float x = 1;
	}

    void Update()
    {


        if (Time.time > timeset && isactive)
        {
            move = true;
            timeset = Time.time + waittime;
            textsta++;
        }

        if (move && !stop)
        {
            this.GetComponent<Text>().color = new Color(0, 0, 0, x);
            if (down)
            {
                x -= 3 * Time.deltaTime;
                if (x <= 0)
                {
                    changetext();
                    down = false;
                }
            }
            else
            {
                x += 3 * Time.deltaTime;
                if (x >= 1)
                {
                    move = false;
                    down = true;
                }
            }
        }


    }

    public void wait()
    {
        if (text2.text != "")
        {
            isactive = true;
            if(textsta % 2 == 1)
            {
                textsta = 3;
            }
        }
        else
        {
            Debug.Log("!output");
            isactive = false;
            textsta = 4;
            changetext();
            GetComponent<Text>().color = new Color(0, 0, 0, 1);
        }
    }

    void changetext()
    {
        if(textsta % 2 == 0)
        {
            this.GetComponent<Text>().text = text1.text;
        }
        if (textsta % 2 == 1)
        {
            this.GetComponent<Text>().text = text2.text;
        }
    }
}
