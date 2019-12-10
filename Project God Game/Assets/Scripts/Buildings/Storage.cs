using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Storage : Assignable
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
    public int storageRate;
    public int totalCount;
    public int lvl = 1;

    public int woodCount;
    public int stoneCount;
    public int ironCount;
    public int foodCount;

    public float countdown;

    public bool full;
    public bool townhall;

    private float timer;

    void Start()
    {
        sm.AddStorage(gameObject);
        type = "Storage";
    }

    void Update()
    {
        if (assigned && !townhall)
        {
            timer -= Time.deltaTime;

            totalCount = woodCount + stoneCount + ironCount + foodCount;

            if (timer <= 0)
            {
                storageRate = (lvl + stats.Str) / 2;

                if (totalCount == storageCapacity)
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
                timer = countdown;
            }
        }
        else if (townhall)
        {
            timer -= Time.deltaTime;

            totalCount = woodCount + stoneCount + ironCount + foodCount;

            if (timer <= 0)
            {
                storageRate = 1;

                if (totalCount == storageCapacity)
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
                timer = countdown;
            }
        }
        
    }

    public void Store(string stored)
    {
        switch (stored)
        {
            case "Wood":
                if (gatheredWood.Value > 0 && !full)
                {
                    gatheredWood.Value -= storageRate;
                    storedWood.Value += storageRate;
                    woodCount += storageRate;
                }
                break;

            case "Stone":
                if (gatheredStone.Value > 0 && !full)
                {
                    gatheredStone.Value -= storageRate;
                    storedStone.Value += storageRate;
                    stoneCount += storageRate;
                }
                break;

            case "Iron":
                if (gatheredIron.Value > 0 && !full)
                {
                    gatheredIron.Value -= storageRate;
                    storedIron.Value += storageRate;
                    ironCount += storageRate;
                }
                break;

            case "Food":
                if (gatheredFood.Value > 0 && !full)
                {
                    gatheredFood.Value -= storageRate;
                    storedFood.Value += storageRate;
                    foodCount += storageRate;
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