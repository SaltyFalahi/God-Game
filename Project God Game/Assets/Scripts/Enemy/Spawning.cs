using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject enemyShip;

    public float maxSpawnTimer;
    public float maxSpawns;

    private float spawnCountdown;

    void Start()
    {
        spawnCountdown = maxSpawnTimer;
    }

    void Update()
    {
        if (maxSpawns >= 1)
        {
            spawnCountdown -= Time.deltaTime;

            if (spawnCountdown <= 0)
            {
                maxSpawns--;
                Instantiate(enemyShip, transform.position, Quaternion.identity);
                spawnCountdown = maxSpawnTimer;
            }
        }
    }
}
