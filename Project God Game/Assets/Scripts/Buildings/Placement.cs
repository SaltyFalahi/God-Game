using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public GameObject phantom;

    public Rigidbody rb;

    public GridObject grid;

    public Building building;

    public bool held;

    void Start()
    {
        building = GetComponent<Building>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RaycastHit hit;

        if (!held && !building.placed)
        {
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 5))
            {
                if (hit.transform.gameObject.CompareTag("Floor"))
                {
                    phantom.transform.position = hit.point;
                    phantom.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

                    building.building.transform.position = hit.point;
                    building.building.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

                    building.placed = true;

                    building.RequestResource(building.progress[0].count, building.progress[0].name);
                }
            }
        }
    }
}
