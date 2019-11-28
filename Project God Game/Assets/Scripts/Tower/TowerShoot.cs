using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public GameObject bullet;

    public float shotTimer;

    Transform target;

    void Start()
    {
       
    }

    void Update()
    {
        if (target != null)
        {
            shotTimer -= 1 * Time.deltaTime;
            if (shotTimer <= 0f)
            {
                var bulletInstance = Instantiate(bullet, transform.position, transform.rotation);

                bulletInstance.SendMessage("Target", target);
               
                shotTimer = 3f;
            }
        }
    }

    void Shoot(Transform target)
    {
        this.target = target;
    }
}
