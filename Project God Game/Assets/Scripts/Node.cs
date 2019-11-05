using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public bool isVisited;
    public Vector3 worldPos;
    public Vector2Int index;

    public Node(bool _walkable, Vector3 _worldPos, Vector2Int _index)
    {
        walkable = _walkable;
        worldPos = _worldPos;
        index = _index;
    }
}
