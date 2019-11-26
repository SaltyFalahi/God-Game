using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Research : MonoBehaviour
{
    public List<Progression> progress;

    public IntVariable worship;

    private int index = 0;

    void Update()
    {
        if (worship.Value >= progress[index].count && index < progress.Count)
        {
            BuildTool(progress[index].obj);
            worship.Value -= progress[index].count;
            index++;
        }
    }

    public void BuildTool(GameObject obj)
    {
        Instantiate(obj);
    }
}