using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyForge : Assignable
{
    public List<Progression> progress;

    public StorageManager sm;

    public Request request;

    private int index = 0;

    void Start()
    {
        RequestResource(progress[index].count, progress[index].name);
        index++;
        type = "Keyforge";
    }

    void Update()
    {
        if (assigned)
        {
            if (request.completed && index < progress.Count)
            {
                BuildKey(progress[index - 1].obj);
                RequestResource(progress[index].count, progress[index].name);
                index++;
                request.completed = false;
            }
        }
    }

    public void RequestResource(int value, string type)
    {
        request.count = value;
        request.type = type;
        sm.requests.Add(request);
    }

    public void BuildKey(GameObject key)
    {
        Instantiate(key);
    }
}