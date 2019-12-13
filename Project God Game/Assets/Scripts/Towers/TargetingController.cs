﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingController : MonoBehaviour
{
    Transform enemy;

    public List<GameObject> enemies = new List<GameObject>();

    void Update()
    {
        float distance = Mathf.Infinity;
        float tempDist = Mathf.Infinity;

        for (int i = 0; i < enemies.Count; i++)
        {
            distance = Vector3.Distance(enemies[i].transform.position, transform.position);
            
            if (distance < tempDist)
            {
                tempDist = distance;
                enemy = enemies[i].transform;
            }
        }

        if(enemy != null)
        {
            SendMessage("Shoot", enemy); //inside the TowerShoot script
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Remove(other.gameObject);
        }
    }
}