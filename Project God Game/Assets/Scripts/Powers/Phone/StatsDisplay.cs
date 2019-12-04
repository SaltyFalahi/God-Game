using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    public Text name;
    public Text stats;

    public GameObject target;

    private Assignable building;
    private Production production;
    private Storage storage;
    private KeyForge keyForge;
    private Research research;

    private Villager villager;

    void Start()
    {

    }

    void Update()
    {
        target = GetComponent<PhoneTargeting>().obj;

        if(target != null)
        {
            switch (target.tag)
            {
                case "Villager":

                    villager = target.GetComponent<Villager>();

                    name.text = "Name: " + villager.villagerName;

                    stats.text = "Stats: \n" +
                        "Level: " + villager.Lvl + "\n" +
                        "Str: " + villager.Str + "\n" +
                        "Dex: " + villager.Dex + "\n" +
                        "Int: " + villager.Int + "\n" +
                        "Fth: " + villager.Fth;
                    break;

                case "Building":

                    building = target.GetComponent<Assignable>();

                    name.text = "Name: " + building.name;

                    switch (building.type)
                    {
                        case "Gather":

                            production = target.GetComponent<Production>();

                            if(production.stats != null)
                            {
                                stats.text = "Stats: " +
                                "\n" + "Production Stat: " + production.mainStat.ToString() +
                                "\n" + "Produced Resource: " + production.resource.name +
                                "\n" + "Production Rate: " + production.productionRate +
                                "\n" + "Current Worker: " + production.stats.villagerName;
                            }
                            else
                            {
                                stats.text = "Stats: " +
                                "\n" + "Production Stat: " + production.mainStat.ToString() +
                                "\n" + "Produced Resource: " + production.resource.name +
                                "\n" + "Production Rate: " + production.productionRate +
                                "\n" + "Current Worker: None";
                            }

                            break;

                        case "Storage":

                            storage = target.GetComponent<Storage>();

                            if (storage.stats != null)
                            {
                                stats.text = "Stats: \n" + "Total Capacity: " + storage.totalCount + "/" + storage.storageCapacity +
                                "\n" + "Stored Wood: " + storage.woodCount +
                                "\n" + "Stored Stone: " + storage.stoneCount +
                                "\n" + "Stored Iron: " + storage.ironCount +
                                "\n" + "Stored Food: " + storage.foodCount +
                                "\n" + "Current Worker: " + storage.stats.villagerName;
                            }
                            else
                            {
                                stats.text = "Stats: \n" + "Total Capacity: " + storage.totalCount + "/" + storage.storageCapacity +
                                "\n" + "Stored Wood: " + storage.woodCount +
                                "\n" + "Stored Stone: " + storage.stoneCount +
                                "\n" + "Stored Iron: " + storage.ironCount +
                                "\n" + "Stored Food: " + storage.foodCount +
                                "\n" + "Current Worker: None";
                            }

                            break;

                        case "Keyforge":

                            keyForge = target.GetComponent<KeyForge>();

                            if (keyForge.stats != null)
                            {
                                stats.text = "Stats: \n" + "Current Request: " + keyForge.request.type +
                                "\n" + "Current Amount Needed: " + keyForge.request.count +
                                "\n" + "Current Worker: " + keyForge.stats.villagerName;
                            }
                            else
                            {
                                stats.text = "Stats: \n" + "Current Request: " + keyForge.request.type +
                                "\n" + "Current Amount Needed: " + keyForge.request.count +
                                "\n" + "Current Worker: None";
                            }

                            break;

                        case "Research":

                            research = target.GetComponent<Research>();

                            if (research.stats != null)
                            {
                                stats.text = "Stats: \n" + "Current Research: " + research.progress[research.index].name +
                                "\n" + "Current Worker: " + keyForge.stats.villagerName;
                            }
                            else
                            {
                                stats.text = "Stats: \n" + "Current Research: " + research.progress[research.index].name +
                                "\n" + "Current Worker: None";
                            }
                            break;
                    }

                    break;
            }
        }
        else
        {
            name.text = "";
            stats.text = "";
        }
    }
}
