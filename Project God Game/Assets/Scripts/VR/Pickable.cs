﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    public virtual void OnHandHover()
    {
        //highlight yourself
    }

    public virtual void OnHandTrigger(HandController handPara) 
    {
        if (handPara!=null)
        {
            transform.SetParent(handPara.transform);
            
        }
        if (rb)
        {
            rb.isKinematic = true;
        }
    }

    public virtual void OnHandTriggerReleased() 
    {
        transform.SetParent(null);

        if (rb)
        {
            rb.isKinematic = false;
        }
    }
}
