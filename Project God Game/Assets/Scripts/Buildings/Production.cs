using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : Assignable
{
    public enum AllStats
    {
        Str,
        Dex,
        Int,
        Fth
    }

    public AllStats mainStat;

    public IntVariable resource;

    public int productionRate;

    public int lvl = 1;

    public float countdown;

    private int productionStat;

    private float timer;

    private void Start()
    {
        type = "Gather";
    }

    private void Update()
    {
        if (assigned)
        {
            timer -= Time.deltaTime;

            switch (mainStat)
            {
                case AllStats.Str:
                    productionStat = stats.Str;
                    break;

                case AllStats.Dex:
                    productionStat = stats.Dex;
                    break;

                case AllStats.Int:
                    productionStat = stats.Int;
                    break;

                case AllStats.Fth:
                    productionStat = stats.Fth;
                    break;

                default:
                    break;
            }

            if (timer <= 0)
            {
                productionRate = (lvl + productionStat) / 2;
                resource.Value += productionRate;
                timer = countdown;
            }
        }
        else
        {
            stats = null;
            timer = countdown;
        }
    }
}
