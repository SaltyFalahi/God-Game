using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monument : Assignable
{    
    public int buffedRate;

    private int productionRate;

    private void Start()
    {
        type = "Buff";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Altar") && assigned)
        {
            buffedRate = other.GetComponent<Production>().productionRate * 2;
            other.GetComponent<Production>().productionRate = buffedRate;
            productionRate = other.GetComponent<Production>().productionRate;
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
