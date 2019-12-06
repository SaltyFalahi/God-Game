using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public GameObject phantom;

    public Transform point;

    public Rigidbody rb;

    public NodeGrid grid;

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

        if (!held)
        {
            rb.isKinematic = false;

            Debug.DrawLine(transform.position, -Vector3.up * 10);

            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 10))
            {
                rb.isKinematic = true;

                phantom.transform.position = grid.NodeFromWorldPoint(point.position).nodeWorldPos;

                building.placed = true;

                building.RequestResource(building.progress[0].count, building.progress[0].name);
                building.index++;
            }
        }
    }
}
