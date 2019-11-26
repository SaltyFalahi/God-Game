using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Storage : MonoBehaviour
{
    public StorageManager sm;

    public IntVariable gatheredWood;
    public IntVariable gatheredStone;
    public IntVariable gatheredIron;
    public IntVariable gatheredFood;

    public IntVariable storedWood;
    public IntVariable storedStone;
    public IntVariable storedIron;
    public IntVariable storedFood;

    public int storageCapacity;

    public int woodCount;
    public int stoneCount;
    public int ironCount;
    public int foodCount;

    public bool full;

    public int totalCount;

    void Start()
    {
        sm.AddStorage(gameObject);
    }

    void Update()
    {
        totalCount = woodCount + stoneCount + ironCount + foodCount;

        if(totalCount == storageCapacity)
        {
            full = true;
        }
        else
        {
            full = false;
            Store("Wood");
            Store("Stone");
            Store("Iron");
            Store("Food");
        }
    }

    public void Store(string stored)
    {
        switch (stored)
        {
            case "Wood":
                if (gatheredWood.Value > 0 && !full)
                {
                    gatheredWood.Value--;
                    storedWood.Value++;
                    woodCount++;
                }
                break;

            case "Stone":
                if (gatheredStone.Value > 0 && !full)
                {
                    gatheredStone.Value--;
                    storedStone.Value++;
                    stoneCount++;
                }
                break;

            case "Iron":
                if (gatheredIron.Value > 0 && !full)
                {
                    gatheredIron.Value--;
                    storedIron.Value++;
                    ironCount++;
                }
                break;

            case "Food":
                if (gatheredFood.Value > 0 && !full)
                {
                    gatheredFood.Value--;
                    storedFood.Value++;
                    foodCount++;
                }
                break;
        }
    }

    public void Remove(string stored)
    {
        switch (stored)
        {
            case "Wood":
                if (storedWood.Value > 0)
                {
                    storedWood.Value--;
                    woodCount--;
                }
                break;

            case "Stone":
                if (storedStone.Value > 0)
                {
                    storedStone.Value--;
                    stoneCount--;
                }
                break;

            case "Iron":
                if (storedIron.Value > 0)
                {
                    storedIron.Value--;
                    ironCount--;
                }
                break;

            case "Food":
                if (storedFood.Value > 0)
                {
                    storedFood.Value--;
                    foodCount--;
                }
                break;
        }
    }
}