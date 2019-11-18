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
        if(villager != null && free)
        {
            villager.transform.position = workPos.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Villager")
        {
            //Highlight Color

            if (free)
            {
                villager = other.gameObject;
                GetComponent<Production>().stats = villager.GetComponent<Villager>();
                GetComponent<Production>().assigned = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Villager")
        {
            GetComponent<Production>().assigned = false;
            villager = null;
        }
    }
}
