using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHandHover()
    {
        
    }
    public void OnHandTrigger(HandController handPara) 
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
    public void OnHandTriggerRelease() 
    {
        if (rb)
        {
            rb.isKinematic = false;
        }
    }
}
