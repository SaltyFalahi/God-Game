using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monument : Assignable
{    
    public int buffedRate;
    public int lvl = 1;

    private int productionRate;

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
                stats.Fth++;
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
        if (other.CompareTag("Altar") && assigned)
        {
            productionRate = other.GetComponent<Production>().productionRate;
            buffedRate = other.GetComponent<Production>().productionRate + (lvl + stats.Fth) / 2;
            other.GetComponent<Production>().productionRate = buffedRate;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Altar") && assigned)
        {
            other.GetComponent<Production>().productionRate = productionRate;
        }
    }
}
