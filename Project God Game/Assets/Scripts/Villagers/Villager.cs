using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public VillagerStats stats;

    void Start()
    {
        stats.Str = Random.Range(1, 3);
        stats.Dex = Random.Range(1, 3);
        stats.Int = Random.Range(1, 3);
        stats.Fth = Random.Range(1, 3);

        stats.level = 1;

        stats.villager = gameObject;
    }
}
