using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : Assignable
{
    public float buffedTimer;

    public float lvl = 1;

    private float shotTimer;

    private void Start()
    {
        type = "Buff";
    }

    private void Update()
    {
        if (assigned)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                lvl++;
                stats.Lvl++;
                stats.Int++;
                countdown = timer;
            }
        }
    }

    private void Dead()
    {
        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tower") && assigned)
        {
            shotTimer = other.GetComponent<TowerShoot>().shotTimer;
            buffedTimer = shotTimer - (lvl + stats.Int) / 2;
            other.GetComponent<TowerShoot>().shotTimer = buffedTimer;
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
