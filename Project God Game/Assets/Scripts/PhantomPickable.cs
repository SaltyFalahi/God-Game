using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomPickable : Pickable
{
    private Placement place;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        place = GetComponent<Placement>();
    }

    void Update()
    {

    }

    public override void OnHandHover()
    {

    }

    public override void OnHandTrigger(HandController handPara)
    {
        if (handPara != null)
        {
            transform.SetParent(handPara.transform);
            place.held = true;
        }
        if (rb)
        {
            rb.isKinematic = true;
        }
    }
    public override void OnHandTriggerReleased()
    {
        transform.SetParent(null);

        place.held = false;

        if (rb)
        {
            rb.isKinematic = false;
        }
    }
}
