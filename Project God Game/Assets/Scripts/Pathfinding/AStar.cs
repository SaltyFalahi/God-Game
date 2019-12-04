using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    public Transform seeker, target;
    NodeGrid grid;

    private void Awake()
    {
        grid = GetComponent<NodeGrid>();
    }

    void Update()
    {
        FindPath(seeker.position, target.position);
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.NodeFromWorldPoint(startPos);
        Node targetNode = grid.NodeFromWorldPoint(targetPos);

        List<Node> openNode = new List<Node>();
        HashSet<Node> closedNode = new HashSet<Node>(); //refer to https://www.geeksforgeeks.org/hashset-in-c-sharp-with-examples/

        openNode.Add(startNode);

        while(openNode.Count > 0)
        {
            Node currentNode = openNode[0];

            for (int i = 1; i < openNode.Count; i++)
            {
                if (openNode[i].fCost < currentNode.fCost || openNode[i].fCost == currentNode.fCost && openNode[i].hCost < currentNode.hCost)
                {
                    currentNode = openNode[i];
                }
            }

            openNode.Remove(currentNode);
            closedNode.Add(currentNode);

            if (currentNode == targetNode)
            {
                BackPath(startNode, targetNode);
                return;
            }

            foreach (Node neighbor in grid.FindNeighbors(currentNode))
            {
                if (!neighbor.isWalkable || closedNode.Contains(neighbor))
                {
                    continue;
                }

                int newMoveCostToNeighbor = currentNode.gCost + getDist(currentNode, neighbor);

                if (newMoveCostToNeighbor < neighbor.gCost || !openNode.Contains(neighbor))
                {
                    neighbor.gCost = newMoveCostToNeighbor;
                    neighbor.hCost = getDist(neighbor, targetNode);

                    neighbor.parent = currentNode;

                    if (!openNode.Contains(neighbor))
                    {
                        openNode.Add(neighbor);
                    }
                }
            }
        }
    }

    void BackPath(Node myStartNode, Node myEndNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = myEndNode;

        while (currentNode != myStartNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.parent;
        }

        path.Reverse();

        grid.path = path;
    }

    int getDist (Node nodeA, Node nodeB)
    {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (distX > distY)
        {
            return 14 * distY + 10 * (distX - distY);
        }
        return 14 * distY + 10 * (distY - distX);
    }
}