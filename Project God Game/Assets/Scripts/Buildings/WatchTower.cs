using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : Assignable
{
    public float buffedRadius;

    private float shotRadius;

    private void Start()
    {
        type = "Buff";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower") && assigned)
        {
            other.GetComponent<SphereCollider>().radius = buffedRadius;
            shotRadius = other.GetComponent<SphereCollider>().radius;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tower") && assigned)
        {
            other.GetComponent<SphereCollider>().radius = shotRadius;
        }
    }
}
