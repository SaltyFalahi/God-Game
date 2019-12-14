using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    public float maxHealth;

    float myHealth;

    void Start()
    {
        myHealth = maxHealth;
    }

    void Update()
    {
        if (myHealth <= 0)
        {
            SendMessage("Dead");
        }
    }

    void Damage(int damage)
    {
        myHealth -= damage;
    }

    void Repair(int health)
    {
        myHealth += health;
    }
}
