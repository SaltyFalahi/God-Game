using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTargeting : MonoBehaviour
{
    public Object target;

    public GameObject obj;

    public Camera current;

    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;

        Debug.DrawRay(transform.position, transform.forward * 50, Color.red);

        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            obj = hit.transform.gameObject;
        }
        else
        {
            obj = null;
        }
    }
}
