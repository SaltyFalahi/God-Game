using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public FloatVariable wood;

    public VillagerStats stats;

    public float countdown;

    private float timer;

    void Start()
    {
        
    }

    void Update()
    {
        if(timer <= 0)
        {
            wood.Value += (int)((1 + stats.Str) / 2);
            timer = countdown;
        }

        Debug.Log(timer);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == stats.villager)
        {
            timer -= Time.deltaTime;
        }
    }
}
