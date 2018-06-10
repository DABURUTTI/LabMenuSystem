using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setobject : MonoBehaviour {

    [SerializeField]
    RawImage get1 = null, get2 = null, set1 = null, set2 = null;

    public void setobjs()
    {
        set1.texture = get1.texture;
        set2.texture = get2.texture;
    }
}
