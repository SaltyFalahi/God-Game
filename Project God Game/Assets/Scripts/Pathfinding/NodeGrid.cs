using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGrid : MonoBehaviour
{
    public LayerMask unwalkableMask;

    public GridObject grid;

    void Start()
    {
        grid.nodeDiameter = grid.nodeRadius * 2;

        grid.gridSizeX = Mathf.RoundToInt(grid.gridWorldSize.x / grid.nodeDiameter);
        grid.gridSizeY = Mathf.RoundToInt(grid.gridWorldSize.y / grid.nodeDiameter);

        CreateGrid();
    }

    void CreateGrid()
    {
        grid.grid = new Node[grid.gridSizeX, grid.gridSizeY];

        Vector3 worldBotLeft = transform.position - Vector3.right * grid.gridWorldSize.x / 2 - Vector3.forward * grid.gridWorldSize.y / 2;

        for (int x = 0; x < grid.gridSizeX; x++)
        {
            for (int y = 0; y < grid.gridSizeY; y++)
            {
                Vector3 worldPoint = worldBotLeft + Vector3.right * (x * grid.nodeDiameter + grid.nodeRadius) + Vector3.forward * (y * grid.nodeDiameter + grid.nodeRadius);
                bool walkable = !(Physics.CheckSphere(worldPoint, grid.nodeRadius, unwalkableMask));
                grid.grid[x, y] = new Node(walkable, worldPoint, x, y);
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireCube(transform.position, new Vector3(grid.gridWorldSize.x, 1, grid.gridWorldSize.y));

    //    if (grid != null)
    //    {
    //        foreach (Node n in grid.grid)
    //        {
    //            Gizmos.DrawCube(n.nodeWorldPos, Vector3.one * (grid.nodeDiameter - 0.1f));
    //        }
    //    }
    //}
}
