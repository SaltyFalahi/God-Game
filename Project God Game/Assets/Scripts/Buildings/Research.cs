using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Research : Assignable
{
    public List<Progression> progress;

    public IntVariable worship;

    public int index = 0;
    public int lvl = 1;

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
                worship.Value -= progress[index].count - (lvl + stats.Fth) / 2;
                index++;
            }

            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                lvl++;
                stats.Lvl++;
                stats.Int++;
                countdown = timer;
            }
        }
    }

    private void Dead()
    {
        Destroy(this);
    }

    public void BuildTool(GameObject obj)
    {
        Instantiate(obj);
    }
}