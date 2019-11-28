using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    public List<GameObject> storages = new List<GameObject>();
    public List<Request> requests = new List<Request>();

    public int totalStorage;

    void Update()
    {
        totalStorage = storages.Count * 50;

        if (requests.Count > 0)
        {
            for (int i = 0; i < requests.Count; i++)
            {
                GetResource(requests[i]);

                if (requests[i].completed)
                {
                    requests.RemoveAt(i);
                }
            }
        }
    }

    public void AddStorage(GameObject obj)
    {
        storages.Add(obj);
    }

    public void RemoveStorage(GameObject obj)
    {
        storages.Remove(obj);
    }

    public void GetResource(Request request)
    {
        for (int i = 0; i < storages.Count; i++)
        {
            Storage current = storages[i].GetComponent<Storage>();

            switch (request.type)
            {
                case "Wood":
                    for (int j = 0; j < current.woodCount; j++)
                    {
                        current.Remove(request.type);
                        request.count--;
                    }
                    break;

                case "Stone":
                    while (current.stoneCount > 0)
                    {
                        current.Remove(request.type);
                        request.count--;
                    }
                    break;

                case "Iron":
                    while (current.ironCount > 0)
                    {
                        current.Remove(request.type);
                        request.count--;
                    }
                    break;

                case "Food":
                    while (current.foodCount > 0)
                    {
                        current.Remove(request.type);
                        request.count--;
                    }
                    break;
            }

            if (request.count == 0)
            {
                request.completed = true;
                break;
            }
        }
    }
}
