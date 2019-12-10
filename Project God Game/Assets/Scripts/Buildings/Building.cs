using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public StorageManager sm;

    public List<Progression> progress;

    public Request request;

    public Placement placement;

    public GameObject building;

    public bool placed;

    public int index = 0;

    void Start()
    {
        placement = GetComponent<Placement>();
    }

    void Update()
    {
        if (placed)
        {
            if (request.completed)
            {
                index++;

                if(index < progress.Count)
                {
                    RequestResource(progress[index].count, progress[index].name);
                    request.completed = false;
                }
                else
                {
                    Debug.Log("Completed");
                    Build();
                }
            }
        }
    }

    public void RequestResource(int value, string type)
    {
        request.count = value;
        request.type = type;
        sm.requests.Add(request);
    }

    public void Build()
    {
        Instantiate(building);

        building.transform.position = transform.position;
        building.transform.rotation = transform.rotation;

        Destroy(this.gameObject);
    }
}
