using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    Vector3 acc;
    Vector3 desired;
    Vector3 seekV;
    Vector3 circlePos;
    Vector3 rotated;
    Rigidbody rb;

    public float force;
    public float speed;
    public float circleDist;
    public float circleRad;
    float randomAngle;

    public GameObject chut;
    Vector3 mousepos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        // acc = Seek(chut.transform.position);
        acc = WanderMethod();
        rb.velocity += acc;

    }
    public Vector3 Seek(Vector3 seekTarget)
    {

        desired = (seekTarget - transform.position).normalized * speed;
        seekV = (desired - rb.velocity);
        if (seekV.magnitude > force)
        {
            //seekV.Scale(new Vector3(force, force, force));
            seekV = seekV.normalized * force;
        }
        return seekV;
    }
    public Vector3 WanderMethod()
    {

        circlePos = transform.position + rb.velocity.normalized * circleDist;
        randomAngle = Random.Range(0, 360);
        Vector3 target = circlePos + (Quaternion.Euler(0, randomAngle, 0) * new Vector3(circleRad, 0, circleRad));


        //rotated = circlePos;
        //rotated= Quaternion.Euler(0, randomAngle, 0) * rotated;
        //target = circlePos + rotated;
        // chut.transform.position = target;


        return Seek(target);
    }
}