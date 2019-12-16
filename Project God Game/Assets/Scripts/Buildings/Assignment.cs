using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment : MonoBehaviour
{
    public GameObject villager;

    public Transform workPos;

    public bool assigned;
    
    void Start()
    {

    }

    void Update()
    {
        if (villager != null)
        {
            assigned = true;
        }
        else
        {
            assigned = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Villager" && !assigned)
        {
            villager = other.gameObject;

            if (villager.GetComponent<Villager>().free)
            {
                villager.GetComponent<Rigidbody>().isKinematic = true;

                villager.transform.position = workPos.position;

                GetComponent<Assignable>().stats = villager.GetComponent<Villager>();
                GetComponent<Assignable>().assigned = true;
            }
            else
            {
                villager = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Villager")
        {
            GetComponent<Assignable>().assigned = false;

            villager = null;
        }
    }
}
