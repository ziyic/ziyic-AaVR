using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic_Lights_Scripts : MonoBehaviour
{
    // Start is called before the first frame update
    bool VAccess = true;

    float timer;

    GameObject TL1=new GameObject();
    GameObject TL2;
    GameObject TL3;

    GameObject tl1g;
    GameObject tl1r;
    GameObject tl2g;
    GameObject tl2r;
    GameObject tl3g;
    GameObject tl3r;
    void Start()
    {
        TL1 = GameObject.Find("TL1");
        TL1 = GameObject.Find("TL2");
        TL1 = GameObject.Find("TL3");


        tl1g = TL1.transform.Find("Green light").gameObject;
        tl1r = TL1.transform.Find("Red light").gameObject;
        tl2g = TL2.transform.Find("Green light").gameObject;
        tl2r = TL2.transform.Find("Red light").gameObject;
        tl3g = TL3.transform.Find("Green light").gameObject;
        tl3r = TL3.transform.Find("Red light").gameObject;



    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        route(VAccess);
    }

    void route (bool va)
    {
            tl1g.SetActive(!va);
            tl1r.SetActive(va);

            tl2g.SetActive(va);
            tl2r.SetActive(!va);

            tl3g.SetActive(va);
            tl3r.SetActive(!va);
    }



}
