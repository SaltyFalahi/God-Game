using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    public float maxHealth;

    float myHealth;

    // Start is called before the first frame update
    void Start()
    {
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
}
