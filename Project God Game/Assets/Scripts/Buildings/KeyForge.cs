using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyForge : Assignable
{
    public List<Progression> progress;

    private StorageManager sm;

    public Request request;

    public int lvl = 1;

    private int index = 0;

    void Start()
    {
        sm = StorageManager.SharedInstance;

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

            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                lvl++;
                stats.Lvl++;
                stats.Fth++;

                countdown = timer;
            }
        }
    }

    private void Dead()
    {
        Destroy(this);
    }

    public void RequestResource(int value, string type)
    {
        if (stats)
        {
            request.count = value - (lvl + stats.Fth) / 2;
        }
        else
        {
            request.count = value;
        }

        request.type = type;
        sm.requests.Add(request);
    }

    public void BuildKey(GameObject key)
    {
        Instantiate(key);

        key.transform.position = transform.position;
    }
}