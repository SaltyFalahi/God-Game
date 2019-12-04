using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Research : Assignable
{
    public List<Progression> progress;

    public IntVariable worship;

    public int index = 0;

    private void Start()
    {
        type = "Research";
    }

    void Update()
    {
        if (assigned)
        {
            if (worship.Value >= progress[index].count && index < progress.Count)
            {
                BuildTool(progress[index].obj);
                worship.Value -= progress[index].count;
                index++;
            }
        }
    }

    public void BuildTool(GameObject obj)
    {
        Instantiate(obj);
    }
}