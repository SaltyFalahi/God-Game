using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerPickable : Pickable
{
    public Transform pivot;

    private Villager villager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        villager = GetComponent<Villager>();
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
            transform.localPosition = pivot.localPosition;
            rb.isKinematic = true;
            villager.free = false;
        }
    }
    public override void OnHandTriggerReleased()
    {
        transform.SetParent(null);
        rb.isKinematic = false;
        villager.free = true;
    }
}
