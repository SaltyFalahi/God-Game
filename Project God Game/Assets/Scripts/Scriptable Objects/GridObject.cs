using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GridObject : ScriptableObject
{
    public Vector2 gridWorldSize;

    public float nodeRadius;

    public Node[,] grid;

    public float nodeDiameter;

    public int gridSizeX;
    public int gridSizeY;
}
