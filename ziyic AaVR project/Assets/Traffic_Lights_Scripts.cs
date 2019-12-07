using System.Collections;
using System.Timers;
using System.Collections.Generic;
using UnityEngine;

public class Traffic_Lights_Scripts : MonoBehaviour
{
    // Start is called before the first frame update
    bool VAccess = true;

    int time=0;
    
    public GameObject tl1g;
    public GameObject tl1r;
    public GameObject tl2g;
    public GameObject tl2r;
    public GameObject tl3g;
    public  GameObject tl3r;

    private static Timer aTimer;

    void Start()
    {
        


        tl1g.SetActive(true);
        tl1r.SetActive(true);

        tl2g.SetActive(false);
        tl2r.SetActive(false);

        tl3g.SetActive(false);
        tl3r.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        int transcnt = 0;
        time++;
        if (time==72)
        {
            transcnt++;

            if (transcnt%2==0)
            {
                uvaroute();
            }
            else if (transcnt % 2 == 1)
            {
                varoute();
            }
            time = 0;
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
        tl1g.SetActive(true);
        tl1r.SetActive(false);

        tl2g.SetActive(false);
        tl2r.SetActive(true);

        tl3g.SetActive(false);
        tl3r.SetActive(true);

    }



}
