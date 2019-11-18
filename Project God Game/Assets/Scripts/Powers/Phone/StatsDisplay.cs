using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    public Text name;
    public Text stats;

    public GameObject target;

    private Production building;

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

                    building = target.GetComponent<Production>();

                    name.text = "Name: " + building.name;

                    stats.text = "Stats: \n" +
                        "Production Stat: " + building.mainStat.ToString() + "\n" +
                        "Produced Resource: " + building.resource.name + "\n" +
                        "Production Rate: " + building.productionRate;
                    break;

                default:
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
