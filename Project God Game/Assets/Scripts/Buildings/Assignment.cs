using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment : MonoBehaviour
{
    public GameObject villager;

    public Transform workPos;

    public bool free;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Villager")
        {
            //Highlight Color

            if (free)
            {
                villager = other.gameObject;

                villager.transform.position = workPos.position;

                GetComponent<Assignable>().stats = villager.GetComponent<Villager>();
                GetComponent<Assignable>().assigned = true;
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
