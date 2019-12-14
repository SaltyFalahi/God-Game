using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerSpawning : MonoBehaviour
{
    public GameObject[] villagers;
    public GameObject[] villagerModels;

    public IntVariable food;

    public Transform[] spawn;

    private GameObject prefab;

    void Start()
    {
        
    }

    void Update()
    {
        villagers = GameObject.FindGameObjectsWithTag("Villager");

        if (food.Value >= (2 + Mathf.Pow(villagers.Length, 1.5f)))
        {
            prefab = villagerModels[Random.Range(0, villagerModels.Length)];

            Instantiate(prefab);

            prefab.transform.position = spawn[Random.Range(0, spawn.Length)].transform.position;

            food.Value -= (int)(2 + Mathf.Pow(villagers.Length, 1.5f));
        }
    }
}
