using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : Assignable
{
    public GameObject bullet;

    public float shotTimer;

    public int lvl;

    private Transform target;

    private float shotCountdown;

    void Start()
    {

    }

    void Update()
    {
        if (target != null && assigned)
        {
            shotCountdown -= Time.deltaTime;
            countdown -= Time.deltaTime;

            if (shotCountdown <= 0f)
            {
                var bulletInstance = Instantiate(bullet, transform.position, transform.rotation);

                bulletInstance.SendMessage("Target", target);

                shotCountdown = shotTimer - (lvl + stats.Dex) / 2;
            }

            if (countdown <= 0)
            {
                lvl++;
                stats.Lvl++;
                stats.Dex++;

                countdown = timer;
            }
        }
    }

    void Shoot(Transform target)
    {
        this.target = target;
    }
}
