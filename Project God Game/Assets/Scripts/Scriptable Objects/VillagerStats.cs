using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class VillagerStats : ScriptableObject
{
    public int level;

    public float Str;
    public float Dex;
    public float Int;
    public float Fth;

    public GameObject villager;
}
