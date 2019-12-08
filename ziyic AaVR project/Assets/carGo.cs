using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carGo : MonoBehaviour
{
    public List<Transform> rps;
    public List<Transform> carRoute;
    public int routeNo = 0;
    public int targetRP = 0;

    float dist;
    public bool go = false;
    public float initialDelay;

    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        initRPS();
    }

    private void initRPS()
    {
        rps = new List<Transform>();
        GameObject rp;

        rp = GameObject.Find("RP1");
        rps.Add(rp.transform);

        rp = GameObject.Find("RP2");
        rps.Add(rp.transform);

        rp = GameObject.Find("RP3");
        rps.Add(rp.transform);

        rp = GameObject.Find("RP4");
        rps.Add(rp.transform);

        rp = GameObject.Find("RP5");
        rps.Add(rp.transform);

        rp = GameObject.Find("RP6");
        rps.Add(rp.transform);

        rp = GameObject.Find("RP7");
        rps.Add(rp.transform);

        rp = GameObject.Find("RP8");
        rps.Add(rp.transform);

        initialDelay = Random.Range(10.0f, 20.0f);
        transform.position = new Vector3(0.0f, -5.0f, 0.0f);
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

        Vector3 displacement = carRoute[targetRP].position - transform.position;
        displacement.y = 0;
        dist = displacement.magnitude;

        if (dist < 0.1f)
        {
            targetRP++;
            if (targetRP >= carRoute.Count)
            {
                SetRoute();
                return;
            }
        }

        //calculate velocity for this frame
        var velocity = displacement;
        velocity.Normalize();
        velocity *= 2.5f;//apply velocity
        Vector3 newPosition = transform.position;
        newPosition += velocity * Time.deltaTime;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(newPosition);

        //align to velocity
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, velocity, 40.0f * Time.deltaTime, 0f);
        Quaternion rotation = Quaternion.LookRotation(desiredForward); rb.MoveRotation(rotation);

    }

    void SetRoute()
    {//randomise the next carRoute
        routeNo = Random.Range(0, 2);
        //set the carRoutewaypoints
        if (routeNo == 0)
        {
            carRoute = new List<Transform>
            {
                rps[0],
                rps[1],
                rps[2],
                rps[3]
            };

        }
        else if (routeNo == 1)
        {
            carRoute = new List<Transform>
            {
                rps[1],
                rps[2],
                rps[3],
                rps[0]
            };
        }
        //else if (routeNo == 2)
        //{
        //    carRoute = new List<Transform>
        //    {
        //        rps[2],
        //        rps[1],
        //        rps[4],
        //        rps[5],
        //        rps[6]
        //    };
        //}
        //else if (routeNo == 3)
        //{
        //    carRoute = new List<Transform>
        //    {
        //        rps[2],
        //        rps[1],
        //        rps[4],
        //        rps[5],
        //        rps[7]
        //    };
        //}
        //else if (routeNo == 4)
        //{
        //    carRoute = new List<Transform>
        //    {
        //        rps[3],
        //        rps[4],
        //        rps[5],
        //        rps[6]
        //    };
        //}
        //else if (routeNo == 5)
        //{
        //    carRoute = new List<Transform>
        //    {
        //        rps[3],
        //        rps[4],
        //        rps[5],
        //        rps[7]
        //    };
        //}
        //else if (routeNo == 6)
        //{
        //    carRoute = new List<Transform>
        //    {
        //        rps[6],
        //        rps[5],
        //        rps[4],
        //        rps[0]
        //    };
        //}
        //else if (routeNo == 7)
        //{
        //    carRoute = new List<Transform>
        //    {
        //        rps[6],
        //        rps[5],
        //        rps[4],
        //        rps[3]
        //    };
        //}
        //else if (routeNo == 8)
        //{
        //    carRoute = new List<Transform>
        //    {
        //        rps[6],
        //        rps[5],
        //        rps[4],
        //        rps[1],
        //        rps[2]
        //    };
        //}
        //else if (routeNo == 9)
        //{
        //    carRoute = new List<Transform>
        //    {
        //        rps[7],
        //        rps[5],
        //        rps[4],
        //        rps[0]
        //    };
        //}
        //else if (routeNo == 10)
        //{
        //    carRoute = new List<Transform>
        //    {
        //        rps[7],
        //        rps[5],
        //        rps[4],
        //        rps[3]
        //    };
        //}
        //else if (routeNo == 11)
        //{
        //    carRoute = new List<Transform>
        //    {
        //        rps[7],
        //        rps[5],
        //        rps[4],
        //        rps[1],
        //        rps[2]
        //    };
        //}
        //initialise position and waypoint counter
        transform.position = new Vector3(carRoute[0].position.x, 0.0f, carRoute[0].position.z);
        targetRP = 1;
    }
}
