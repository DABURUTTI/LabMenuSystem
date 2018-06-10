using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settab : MonoBehaviour {
    [SerializeField]
    Toggle tog;
    [SerializeField]
    public MenuContloll men;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            push1();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            push2();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            push3();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            push4();
        }
    }

    public void push1()
    {
        tog.isOn = true;
        men.menust = 0;
        men.setpoint_now();
        
    }

    public void push2()
    {
        tog.isOn = true;
        men.menust = 1;
        men.setpoint_now();
    }

    public void push3()
    {
        tog.isOn = true;
        men.menust = 2;
        men.setpoint_now();
    }

    public void push4()
    {
        tog.isOn = true;
        men.menust = 3;
        men.setpoint_now();
    }
}
