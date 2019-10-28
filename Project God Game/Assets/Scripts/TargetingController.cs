using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingController : MonoBehaviour
{
    public Transform target;

    public float maxRange;
    public float minRange;
    public float distance;
    public float rotationSpeed;

    public bool hasTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        Vector3 posDiff = target.position - transform.position;
        if (distance <= maxRange && distance >= minRange)
        {
            hasTarget = true;
            Quaternion rotate = Quaternion.LookRotation(posDiff);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotate, rotationSpeed * Time.deltaTime);
        }
        else
        {
            hasTarget = false;
        }
    }
}
