using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public GameObject phantom;

    public Transform point;

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

        if (!held)
        {
            rb.isKinematic = false;

            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 10))
            {
                rb.isKinematic = true;

                phantom.transform.position = UnitPosition(point.position).nodeWorldPos;

                building.placed = true;

                building.RequestResource(building.progress[0].count, building.progress[0].name);
                building.index++;
            }
        }
    }

    public Node UnitPosition(Vector3 worldPosition)
    {
        float percentX = (worldPosition.x + grid.gridWorldSize.x / 2) / grid.gridWorldSize.x;
        float percentY = (worldPosition.z + grid.gridWorldSize.y / 2) / grid.gridWorldSize.y;

        percentX = Mathf.Clamp01(percentX);
        percentY = Mathf.Clamp01(percentY);

        int x = Mathf.RoundToInt((grid.gridSizeX - 1) * percentX);
        int y = Mathf.RoundToInt((grid.gridSizeX - 1) * percentY);

        return grid.grid[x, y];
    }
}
