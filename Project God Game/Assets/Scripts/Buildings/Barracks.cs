using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : Assignable
{
    public float buffedTimer;

    private float shotTimer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower") && assigned)
        {
            other.GetComponent<TowerShoot>().shotTimer = buffedTimer;
            shotTimer = other.GetComponent<TowerShoot>().shotTimer;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tower") && assigned)
        {
            other.GetComponent<TowerShoot>().shotTimer = shotTimer;
        }
    }
}
