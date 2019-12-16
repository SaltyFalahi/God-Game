using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : Assignable
{
    public float buffedRadius;

    public int lvl = 1;

    private float shotRadius;

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
            shotRadius = other.GetComponent<SphereCollider>().radius;
            buffedRadius = shotRadius + (lvl + stats.Int) / 2;
            other.GetComponent<SphereCollider>().radius = buffedRadius;
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
