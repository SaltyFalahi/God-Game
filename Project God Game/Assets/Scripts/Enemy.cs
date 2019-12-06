using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float freezeTimer;
    public float slowTimer;

    AStar myPathfinder;

    float myHealth;
    float freezeCountdown;
    float slowCountdown;

    // Start is called before the first frame update
    void Start()
    {
        myPathfinder = GetComponent<AStar>();
        myHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Damage(int damage)
    {
        myHealth -= damage;
    }

    void Freeze(int damage)
    {
        myHealth -= damage;

        myPathfinder.usedSpeed = 0;

        freezeCountdown -= Time.deltaTime;

        if (freezeCountdown <= 0)
        {
            myPathfinder.usedSpeed = myPathfinder.mySpeed;
            freezeCountdown = freezeTimer;
        }
    }

    void Slow(int damage)
    {
        myHealth -= damage;

        myPathfinder.usedSpeed = myPathfinder.mySpeed / 2;

        freezeCountdown -= Time.deltaTime;

        if (freezeCountdown <= 0)
        {
            myPathfinder.usedSpeed = myPathfinder.mySpeed;
            slowCountdown = slowTimer;
        }
    }
}
