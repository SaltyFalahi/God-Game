using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public TextAsset textFile;

    public string villagerName;

    public int Str;
    public int Dex;
    public int Int;
    public int Fth;

    public int Lvl;

    public bool free = true;

    private string[] names;

    void Start()
    {
        Str = Random.Range(1, 4);
        Dex = Random.Range(1, 4);
        Int = Random.Range(1, 4);
        Fth = Random.Range(1, 4);

        Lvl = 1;

        if(textFile != null)
        {
            names = (textFile.text.Split('\n'));
            villagerName = names[Random.Range(0, names.Length)];
        }
    }
}
