using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBaton : MonoBehaviour
{
    public IntVariable worship;

    public int cost;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && worship.Value >= cost)
        {
            Destroy(other);
            worship.Value -= cost;
        }
    }
}