using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawning : MonoBehaviour
{
    public GameObject[] villagers;

    public IntVariable food;

    public GameObject prefab;

    public Transform spawn;

    void Start()
    {
        
    }

    void Update()
    {
        villagers = GameObject.FindGameObjectsWithTag("Villager");

        if (food.Value >= (2 + Mathf.Pow(villagers.Length, 1.5f)))
        {
            Instantiate(prefab, spawn);

            food.Value -= (int)(2 + Mathf.Pow(villagers.Length, 1.5f));
        }
    }
}
