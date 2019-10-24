using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public int Str;
    public int Dex;
    public int Int;
    public int Fth;

    public int Lvl;

    void Start()
    {
        Str = Random.Range(1, 3);
        Dex = Random.Range(1, 3);
        Int = Random.Range(1, 3);
        Fth = Random.Range(1, 3);

        Lvl = 1;
    }
}
