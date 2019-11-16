using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    Node startNode;
    Node endNode;

    List<Node> openNodes;
    List<Node> path;


    Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<Grid>();
        startNode = grid.grid[0, 0];
        endNode = grid.grid[25, 0];
        openNodes = new List<Node>();
        FindPath();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FindPath()
    {
        List<Node> neighbors = new List<Node>();
        Node currentNode;
        openNodes.Add(startNode);

        while (true)
        {
            openNodes.Sort();

            currentNode = openNodes[0];

            openNodes.Remove(currentNode);

            currentNode.isVisited = true;

            if (currentNode == endNode)
            {
                Debug.Log("Woohoo");
                path = GetPath(currentNode);

                for (int i = 0; i < path.Count; i++)
                {
                    GameObject cubeCheck = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cubeCheck.GetComponent<Renderer>().material.color = Color.green;
                    cubeCheck.transform.position = path[i].worldPos;
                }
                break;
            }

            Node newNeighbor;
            //---------find noobers----------
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (currentNode.index.x == currentNode.index.x + x && currentNode.index.y == currentNode.index.y + y)
                    {
                        continue;
                    }

                    if (currentNode.index.x + x >= 0 && currentNode.index.x + x <= grid.gridSizeX && currentNode.index.y + y >= 0 && currentNode.index.y + y <= grid.gridSizeY)
                    {
                        newNeighbor = grid.grid[currentNode.index.x + x, currentNode.index.y + y];
                        neighbors.Add(newNeighbor);
                    }
                }
            }
            //---------find noobers----------

            for (int i = 0; i < neighbors.Count; i++)
            {
                if (neighbors[i].isVisited && !neighbors[i].walkable)
                {
                    continue;
                }

                int newMovementCostToNeighbor = currentNode.gCost + (int)CalculateDistance(currentNode, neighbors[i]);

                if (newMovementCostToNeighbor < neighbors[i].gCost || !openNodes.Contains(neighbors[i]))
                {
                    neighbors[i].parent = currentNode;
                    neighbors[i].hCost = (int)CalculateDistance(currentNode, endNode);
                    neighbors[i].gCost = newMovementCostToNeighbor;
                    neighbors[i].fCost = neighbors[i].gCost + neighbors[i].hCost;

                    if (!openNodes.Contains(neighbors[i]))
                    {
                        openNodes.Add(neighbors[i]);
                    }
                }
            }

            if (openNodes.Count <= 0)
            {
                break;
            }
        }
    }

    float CalculateDistance(Node nodeA, Node nodeB)
    {
        return Mathf.Abs((nodeA.worldPos.x - nodeB.worldPos.x) - (nodeA.worldPos.y - nodeB.worldPos.y));
    }

    List<Node> GetPath(Node _node)
    {
        List<Node> path = new List<Node>();

        Node _currentNode = _node;
        while (true)
        {
            if (_currentNode != null)
            {
                path.Add(_currentNode);
                _currentNode = _currentNode.parent;
            }
            else
            {
                path.Reverse();
                return path;
            }
        }
    }
}
