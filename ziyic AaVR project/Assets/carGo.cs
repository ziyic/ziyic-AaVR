using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carGo : MonoBehaviour
{
    public List<Transform> rps;
    public List<Transform> carRoute;
    public int routeNo = 0;
    public int targetRP = 0;

    Transform car;

    public float timer = 10;

    float dist;
    public bool go = false;
    public float initialDelay;

    bool isgo = false;//该不该走
    bool stoped = false;//停没停过
    bool goc = false;//是否为继续走的情况
    bool first = true;//是否第一次运行

    private Vector3 velocity;
    private Vector3 speed = new Vector3(0, 0, 0);

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

        
        car = GameObject.Find("Car_1").transform;

        initialDelay = Random.Range(0.0f, 15.0f);
        transform.position = new Vector3(0.0f, -5.0f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!go && (first || (isgo && stoped)))
        {
            initialDelay -= Time.deltaTime;
            if (initialDelay <= 0.0f)
            {
                go = true;
                SetRoute();
                first = false;
                stoped = false;
                goc=false;
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
        Quaternion rotation = Quaternion.LookRotation(desiredForward);
        rb.MoveRotation(rotation);

        Tick();

        Carstop1();
        Carstop2();
    }

    private void Tick()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            isgo = !isgo;
            timer = 10;
        }
    }

    private void Carstop2()
    {
        if ((car.position.z < 10) && (car.position.z > 6.5)&& (car.position.x > 0) && (car.position.x < 6.5))
        {
            if (!isgo)
            {
                GetComponent<Rigidbody>().MovePosition(car.position + speed * Time.deltaTime);
                stoped = true;
            }
            else if (isgo && stoped)
            {
                go = false;
                goc = true;
                routeNo = 4;
            }
        }
    }

    public void Carstop1()
    {

        if ((car.position.z < -6.5) && (car.position.z > -10)&&(car.position.x < 0) && (car.position.x > -6.5))
        {
            if (!isgo)
            {
                GetComponent<Rigidbody>().MovePosition(car.position + speed * Time.deltaTime);
                stoped = true;
            }

            else if (isgo && stoped)
            {
                go = false;
                goc = true;
                routeNo = 3;
            }
        }
    }




    void SetRoute()
    {//randomise the next carRoute
        if (goc==false)
        {
            routeNo = Random.Range(0, 2);
            //set the carRoutewaypoints    
        }

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

        else if (routeNo == 3)
        {
            carRoute = new List<Transform>
            {
                 this.transform,
                 rps[1],
                 rps[2],
                 rps[3],
                 rps[0]
            };
        }
        else if (routeNo == 4)
        {
            carRoute = new List<Transform>
            {
                this.transform,
                 rps[3],
                 rps[0],
                 rps[1],
                 rps[2]
            };  
        }
        //initialise position and waypoint counter
        transform.position = new Vector3(carRoute[0].position.x, 0.0f, carRoute[0].position.z);
        targetRP = 1;
    }
}
