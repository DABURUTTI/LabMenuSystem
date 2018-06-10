using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabbutton : MonoBehaviour {

    public settab_2 tab;

    public void push1()
    {
        tab.menust = 0;
        tab.setpoint_now();
    }
    public void push2()
    {
        tab.menust = 1;
        tab.setpoint_now();
    }
    public void push3()
    {
        tab.menust = 2;
        tab.setpoint_now();
    }
    public void push4()
    {
        tab.menust = 3;
        tab.setpoint_now();
    }
}
