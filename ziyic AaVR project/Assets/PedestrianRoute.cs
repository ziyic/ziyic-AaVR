using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianRoute : MonoBehaviour
{
    public List<Transform> wps;
    // Start is called before the first frame update
    void Start()
    {
        wps = new List<Transform>();
        GameObject wp;

        wp = GameObject.Find("WP1");
        wps.Add(wp.transform);

        wp = GameObject.Find("WP2");
        wps.Add(wp.transform);

        wp = GameObject.Find("WP3");
        wps.Add(wp.transform);

        wp = GameObject.Find("WP4");
        wps.Add(wp.transform);

        wp = GameObject.Find("WP5");
        wps.Add(wp.transform);

        wp = GameObject.Find("WP6");
        wps.Add(wp.transform);

        wp = GameObject.Find("WP7");
        wps.Add(wp.transform);

        wp = GameObject.Find("WP8");
        wps.Add(wp.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
