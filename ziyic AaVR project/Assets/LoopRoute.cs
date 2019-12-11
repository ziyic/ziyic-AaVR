using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopRoute : MonoBehaviour
{
    public List<Transform> rps;
    public List<Transform> route;
    public int routeNumber = 0;
    public int targetWP = 0;
    public float dist;
   // public bool go = false;
    public bool go = true;
    public float initialDelay;
    private Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        rps = new List<Transform>();
        GameObject rp;

        rp = GameObject.Find("RP5");
        rps.Add(rp.transform);

        rp = GameObject.Find("RP6");
        rps.Add(rp.transform);

        rp = GameObject.Find("RP7");
        rps.Add(rp.transform);

        rp = GameObject.Find("RP8");
        rps.Add(rp.transform);

        initialDelay = Random.Range(2.0f, 12.0f);
        //transform.position = new Vector3(0.0f, -5.0f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!go)
        {
            initialDelay -= Time.deltaTime;
            if (initialDelay <= 0.0f)
            {
                go = true;
                SetRoute();
            }
            else return;
        }
        Vector3 displacement = route[targetWP].position - transform.position;
        displacement.y = 0;
        dist = displacement.magnitude;
        if (dist < 0.1f)
        {
            targetWP++;
            if (targetWP >= route.Count)
            {
                SetRoute();
                return;
            }
        }
        //calculate velocity for this frame
        velocity = displacement;
        velocity.Normalize();
        velocity *= 2.5f;//apply velocityVector3 newPosition = transform.position;
        Vector3 newPosition = transform.position;
        newPosition += velocity * Time.deltaTime;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(newPosition);
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, velocity, 30.0f * Time.deltaTime, 0f);
        Quaternion rotation = Quaternion.LookRotation(desiredForward);
        rb.MoveRotation(rotation);
    }
    void SetRoute()
    {//randomise the next route
        
        if (routeNumber == 0) 
        {
            route = new List<Transform> 
            { 
                rps[0],
                rps[1],
                rps[2],
                rps[3]
            };
        }
        transform.position = new Vector3(route[0].position.x, 0.0f, route[0].position.z);
        targetWP = 1;
    }
}