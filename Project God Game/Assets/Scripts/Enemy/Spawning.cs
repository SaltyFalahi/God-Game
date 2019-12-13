using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject enemyShip;

    public float spawnCountdownTimer;
    public float maxSpawnTimer;

    public float currentSpawnTimer;

    float maxSpawns = 1;


    // Start is called before the first frame update
    void Start()
    {
        currentSpawnTimer = maxSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (maxSpawns >= 1)
        {
            spawnCountdownTimer -= Time.deltaTime;
            if (spawnCountdownTimer <= 0)
            {
                spawnCountdownTimer = 0;
                currentSpawnTimer -= Time.deltaTime;

                if (currentSpawnTimer <= 0)
                {
                    maxSpawns--;
                    Instantiate(enemyShip, transform.position, Quaternion.identity);
                    currentSpawnTimer = maxSpawnTimer;
                }
            }
        }
    }
}
