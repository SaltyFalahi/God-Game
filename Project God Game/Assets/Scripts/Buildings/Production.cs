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

    public float productionTimer;

    private int productionStat;

    private float productionCountdown;

    private void Start()
    {
        type = "Gather";
        productionTimer = 2;
    }

    private void Update()
    {
        if (assigned)
        {
            productionCountdown -= Time.deltaTime;
            countdown -= Time.deltaTime;

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

            if (productionCountdown <= 0)
            {
                productionRate = (lvl + productionStat) / 2;
                resource.Value += productionRate;
                productionCountdown = productionTimer;
            }

            if (countdown <= 0)
            {
                lvl++;
                stats.Lvl++;
                countdown = timer;

                switch (mainStat)
                {
                    case AllStats.Str:
                        stats.Str++;
                        break;

                    case AllStats.Dex:
                        stats.Dex++;
                        break;

                    case AllStats.Int:
                        stats.Int++;
                        break;

                    case AllStats.Fth:
                        stats.Fth++;
                        break;

                    default:
                        break;
                }
            }
        }
        else
        {
            stats = null;
            productionCountdown = productionTimer;
        }
    }

    private void Dead()
    {
        Destroy(this);
    }
}
