using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public Transform shootPos;
    public GameObject bullet;
    public float shotTimer;

    TargetingController targetingController;

    public enum TurretType
    {
        Single,
        AOE,
        Freeze,
        Slow
    }

    public TurretType turretType;

    void Start()
    {
        targetingController = GetComponent<TargetingController>();
    }

    void Update()
    {
        switch (turretType)
        {
            case TurretType.Single:
                if (targetingController.hasTarget)
                {
                    shotTimer -= 1 * Time.deltaTime;
                    if (shotTimer <= 0f)
                    {
                        Instantiate(bullet, new Vector3(shootPos.position.x, shootPos.position.y, shootPos.position.z), transform.rotation);
                        shotTimer = 3f;
                    }

                }
                print("Single Tower");
                break;

            case TurretType.AOE:
                if (targetingController.hasTarget)
                {
                    shotTimer -= 1 * Time.deltaTime;
                    if (shotTimer <= 0f)
                    {
                        Instantiate(bullet, new Vector3(shootPos.position.x, shootPos.position.y, shootPos.position.z), transform.rotation);
                        shotTimer = 5f;
                    }
                }
                print("AOE Tower");
                break;

            case TurretType.Freeze:
                print("Freeze Tower");
                break;

            case TurretType.Slow:
                print("Slow Tower");
                break;
        }
    }
}
