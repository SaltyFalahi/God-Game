using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool isWalkable;

    public Vector3 nodeWorldPos;

    public int gCost;
    public int hCost;
    public int gridX;
    public int gridY;

    public Node parent;

    public Node(bool walkable, Vector3 nodePos, int _gridX, int _gridY)
    {
        isWalkable = walkable;
        nodeWorldPos = nodePos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
