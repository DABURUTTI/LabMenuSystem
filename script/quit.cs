using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour {
    public void end()
    {
        try{
            Application.Quit();
            return;
        }
        catch
        {
            Application.Quit();
            return;
        }
        
    }
}
