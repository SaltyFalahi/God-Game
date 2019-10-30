using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : MonoBehaviour
{
    public enum AllStats
    {
        Str,
        Dex,
        Int,
        Fth
    }

    public AllStats mainStat;

    public FloatVariable resource;

    public Villager stats;

    public int lvl = 1;

    public float countdown;

    public bool assigned;

    private int productionStat;

    private float timer;

    void Update()
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
                resource.Value += (lvl + productionStat) / 2;
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
