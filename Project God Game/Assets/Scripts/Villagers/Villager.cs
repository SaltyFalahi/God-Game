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

    private string[] names;

    void Start()
    {
        Str = Random.Range(1, 3);
        Dex = Random.Range(1, 3);
        Int = Random.Range(1, 3);
        Fth = Random.Range(1, 3);

        Lvl = 1;

        if(textFile != null)
        {
            names = (textFile.text.Split('\n'));
            villagerName = names[Random.Range(0, names.Length - 1)];
        }
    }
}
