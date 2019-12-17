using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Assignable : MonoBehaviour
{
    public Villager stats;

    public string type;

    public float timer = 600;

    public bool assigned;

    protected float countdown = 600;
}