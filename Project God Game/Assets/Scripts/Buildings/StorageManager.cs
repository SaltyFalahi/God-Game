using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManager : MonoBehaviour
{
    public List<GameObject> storages = new List<GameObject>();
    public List<Request> requests = new List<Request>();

    public int totalStorage;

    private void Awake()
    {
       
    }

    void Update()
    {
        totalStorage = storages.Count * 50;

        if (requests.Count > 0)
        {
            for (int i = 0; i < requests.Count; i++)
            {
                StartCoroutine(GetResource(requests[i]));

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

    public IEnumerator GetResource(Request request)
    {
        for (int i = 0; i < storages.Count; i++)
        {
            Storage current = storages[i].GetComponent<Storage>();

            if (request.count == 0)
            {
                request.completed = true;
                break;
            }

            switch (request.type)
            {
                case "Wood":
                    if(current.woodCount >= request.count)
                    {
                        request.count--;
                        current.Remove(request.type);
                        yield return new WaitForSeconds(5);
                    }
                    break;

                case "Stone":
                    for (int j = 0; j < current.stoneCount; j++)
                    {
                        request.count--;
                        yield return new WaitForSeconds(5);
                    }
                    break;

                case "Iron":
                    for (int j = 0; j < current.ironCount; j++)
                    {
                        request.count--;
                        yield return new WaitForSeconds(5);
                    }
                    break;

                case "Food":
                    for (int j = 0; j < current.foodCount; j++)
                    {
                        request.count--;
                        yield return new WaitForSeconds(5);
                    }
                    break;
            }
        }
    }
}

//if(current.woodCount > request.count)
//                    {
//                        current.Remove(request.type);
//                        current.woodCount -= request.count;
//                        request.completed = true;
//                    }