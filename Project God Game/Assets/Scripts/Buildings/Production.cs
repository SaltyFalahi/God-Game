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

    private int productionStat;

    private float timer;

    void Update()
    {
        if (stats != null)
        {
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
        }

        if (timer <= 0)
        {
            resource.Value += (lvl + productionStat) / 2;
            timer = countdown;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Villager")
        {
            stats = other.gameObject.GetComponent<Villager>();
            timer -= Time.deltaTime;
        }
    }
}
