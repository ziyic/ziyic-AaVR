using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic_Lights_Scripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var TL1 = GameObject.Find("TL1").transform;
        var TL2 = GameObject.Find("TL2").transform;
        var TL3 = GameObject.Find("TL3").transform;
        var tl1g = TL1.FindChild("Green light");
        var tl1r = TL1.FindChild("Red light");
        var tl2g = TL1.FindChild("Green light");
        var tl2r = TL1.FindChild("Red light");
        var tl3g = TL1.FindChild("Green light");
        var tl3r = TL1.FindChild("Red light");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
