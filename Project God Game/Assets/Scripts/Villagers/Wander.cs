using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public float force;
    public float speed;
    public float circleDist;
    public float circleRad;

    private Vector3 acc;
    private Vector3 desired;
    private Vector3 seekV;
    private Vector3 circlePos;
    private Vector3 rotated;
    private Vector3 mousepos;

    private Rigidbody rb;

    private float randomAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        acc = WanderMethod();
        rb.velocity += acc;
    }

    public Vector3 Seek(Vector3 seekTarget)
    {
        desired = (seekTarget - transform.position).normalized * speed;
        seekV = (desired - rb.velocity);
        if (seekV.magnitude > force)
        {
            seekV = seekV.normalized * force;
        }
        return seekV;
    }
    public Vector3 WanderMethod()
    {
        circlePos = transform.position + rb.velocity.normalized * circleDist;
        randomAngle = Random.Range(0, 360);
        Vector3 target = circlePos + (Quaternion.Euler(0, randomAngle, 0) * new Vector3(circleRad, 0, circleRad));

        return Seek(target);
    }
}