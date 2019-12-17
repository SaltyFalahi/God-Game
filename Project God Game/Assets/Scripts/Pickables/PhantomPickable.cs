using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhantomPickable : Pickable
{
    public Transform pivot;

    private Placement place;

    void Awake()
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
            //transform.localPosition = pivot.localPosition;
            rb.isKinematic = true;
            place.held = true;
        }
    }

    public override void OnHandTriggerReleased()
    {
        transform.SetParent(null);
        rb.isKinematic = false;
        place.held = false;
    }
}
