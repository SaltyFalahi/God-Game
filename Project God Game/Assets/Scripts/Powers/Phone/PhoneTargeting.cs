using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTargeting : MonoBehaviour
{
    public List<GameObject> targets = new List<GameObject>();

    public GameObject obj;

    public Camera current;

    void Start()
    {
        
    }

    void Update()
    {
        float distance = Mathf.Infinity;
        float tempDist = Mathf.Infinity;

        if(targets.Count == 0)
        {
            obj = null;
        }

        for (int i = 0; i < targets.Count; i++)
        {
            distance = Vector3.Distance(targets[i].transform.position, transform.position);

            if (distance < tempDist)
            {
                tempDist = distance;
                obj = targets[i];
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Hand"))
        {
            targets.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Hand"))
        {
            targets.Remove(other.gameObject);
        }
    }
}
