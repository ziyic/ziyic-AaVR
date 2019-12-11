using System.Collections;
using System.Timers;
using System.Collections.Generic;
using UnityEngine;

public class Traffic_Lights_Scripts : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject tl1g;
    public GameObject tl1r;
    public GameObject tl2g;
    public GameObject tl2r;
    public GameObject tl3g;
    public GameObject tl3r;

    public float timer = 10;
    public float timer2 = 20;

    void Start()
    {
        uvaroute();
    }

    

    // Update is called once per frame
    void Update()
    {
       timer -= Time.deltaTime;
        if (timer < 0)
        {
            uvaroute();
            timer2 = 10;
            timer = 20;
        }

        timer2 -= Time.deltaTime;
        if(timer2 < 0)
        {
            varoute();
            timer = 10;
            timer2 = 20;
        }
    }

    void varoute()
    {
        tl1g.SetActive(false);
        tl1r.SetActive(true);

        tl2g.SetActive(true);
        tl2r.SetActive(false);

        tl3g.SetActive(true);
        tl3r.SetActive(false);
    }

    void uvaroute()
    {
        tl1g.SetActive(false);
        tl1r.SetActive(true);

        tl2g.SetActive(false);
        tl2r.SetActive(true);

        tl3g.SetActive(false);
        tl3r.SetActive(true);

    }
}
