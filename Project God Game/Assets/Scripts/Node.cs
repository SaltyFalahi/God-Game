using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : System.IComparable
{
    public Node parent;
    public bool walkable;
    public bool isVisited;
    public Vector3 worldPos;
    public Vector2Int index;

    public int hCost;
    public int gCost;
    public int fCost;

    public Node(bool _walkable, Vector3 _worldPos, Vector2Int _index)
    {
        walkable = _walkable;
        worldPos = _worldPos;
        index = _index;
    }

    public int CompareTo(object obj)
    {
        if (((Node)obj).fCost < fCost)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}
