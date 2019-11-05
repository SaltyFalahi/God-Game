using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    Node startNode;
    Node endNode;

    List<Node> openNodes;

    Grid grid;
    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<Grid>();
        startNode = grid.grid[0, 0];
        FindPath();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FindPath()
    {
        List<Node> neighbors = new List<Node>();
        Node currentNode = startNode;

        //while (true)
        {
            Node newNeighbor;
            //---------find noobers----------
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (currentNode.index.x == currentNode.index.x + x && currentNode.index.y == currentNode.index.y + y)
                        continue;

                    if (currentNode.index.x + x >= 0 && currentNode.index.x + x <= grid.gridSizeX && currentNode.index.y + y >= 0 && currentNode.index.y + y <= grid.gridSizeY)
                    {
                        newNeighbor = grid.grid[currentNode.index.x + x, currentNode.index.y + y];
                        neighbors.Add(newNeighbor);
                        GameObject cubeCheck = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cubeCheck.GetComponent<Renderer>().material.color = Color.green;
                        cubeCheck.transform.position = newNeighbor.worldPos;
                    }
                }
            }
            //---------find noobers----------
        }
    }
}
