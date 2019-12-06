using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    public Transform seeker;
    public Transform target;
    public Transform building;

    public GridObject grid;

    public List<GameObject> buildings = new List<GameObject>();

    [HideInInspector]
    public float usedSpeed;

    public float mySpeed;
    public float maxForce;
    public float detectRange;
    public float attackRange;
    public float timer;

    public int damage;

    float countdown;

    int index;

    Rigidbody myRb;

    void Awake()
    {
        seeker = transform;
        usedSpeed = mySpeed;
        myRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (RangeCheck(detectRange))
        {
            Vector3 vectVelocity = Vector3.Normalize(building.position - transform.position) * usedSpeed;

            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);

            Vector3 mySteering = vectVelocity - myRb.velocity;

            Vector3.ClampMagnitude(mySteering, maxForce);

            myRb.AddForce(mySteering);

            if (RangeCheck(attackRange))
            {
                countdown -= Time.deltaTime;

                if (countdown <= 0)
                {
                    building.SendMessage("Damage", damage);
                    countdown = timer;
                }
            }
        }
        else
        {
            FindPath(seeker.position, target.position);
            if (transform.position == finalPath[index].nodeWorldPos)
            {
                index++;
            }
            else
            {
                PathFollowing();
            }
        }
    }

    bool RangeCheck(float unitRadius)
    {
        float distance = Mathf.Infinity;
        float tempDist = Mathf.Infinity;

        Vector3 currentPos = transform.position;

        for (int i = 0; i < buildings.Count; i++)
        {
            distance = Vector3.Distance(buildings[i].transform.position, transform.position);

            if (distance < tempDist)
            {
                tempDist = distance;
                building = buildings[i].transform;
            }
        }

        return true;
    }

    void FindPath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = UnitPosition(startPos);
        Node targetNode = UnitPosition(targetPos);

        List<Node> openNode = new List<Node>();
        List<Node> closedNode = new List<Node>();

        openNode.Add(startNode);

        while (openNode.Count > 0)
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

            foreach (Node neighbor in FindNeighbors(currentNode))
            {
                if (!neighbor.isWalkable || closedNode.Contains(neighbor))
                {
                    continue;
                }

                int newMoveCostToNeighbor = currentNode.gCost + GetDist(currentNode, neighbor);

                if (newMoveCostToNeighbor < neighbor.gCost || !openNode.Contains(neighbor))
                {
                    neighbor.gCost = newMoveCostToNeighbor;
                    neighbor.hCost = GetDist(neighbor, targetNode);

                    neighbor.parent = currentNode;

                    if (!openNode.Contains(neighbor))
                    {
                        openNode.Add(neighbor);
                    }
                }
            }
        }
    }

    void PathFollowing()
    {
        Vector3 vectVelocity = Vector3.Normalize(finalPath[index].nodeWorldPos - transform.position) * usedSpeed;

        vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);

        Vector3 mySteering = vectVelocity - myRb.velocity;

        Vector3.ClampMagnitude(mySteering, maxForce);

        myRb.AddForce(mySteering);
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

        finalPath = path;
    }

    int GetDist(Node nodeA, Node nodeB)
    {
        int distX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
        int distY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

        if (distX > distY)
        {
            return 14 * distY + 10 * (distX - distY);
        }
        return 14 * distY + 10 * (distY - distX);
    }

    public List<Node> FindNeighbors(Node neighbors)
    {
        List<Node> _neighbors = new List<Node>();

        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }

                int checkX = neighbors.gridX + x;
                int checkY = neighbors.gridY + y;

                if (checkX >= 0 && checkX < grid.gridSizeX && checkY >= 0 && checkY < grid.gridSizeY)
                {
                    _neighbors.Add(grid.grid[checkX, checkY]);
                }
            }
        }

        return _neighbors;
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

    public List<Node> finalPath;
}