using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Transform landingPoint;

    public GameObject enemyUnit;
    public GameObject unitSpawnPoint;

    public float mySpeed;
    public float maxForce;
    public float spawnDist;
    public float maxSpawnTimer;
    public float maxSpawns;

    private float spawnCountdown;

    Rigidbody myRb;

    float distance;

    void Awake()
    {
        myRb = GetComponent<Rigidbody>();
        landingPoint = GameObject.FindGameObjectWithTag("Landing Point").transform;
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, landingPoint.position);

        if (distance <= spawnDist)
        {
            SpawnUnit();
        }

        Seek();
    }

    void Seek()
    {
        Vector3 positionDiff = landingPoint.position - transform.position;

        float slowingRadius = 30f;
        float checkDist = Vector3.Distance(transform.position, landingPoint.position);
        Quaternion rotation = Quaternion.LookRotation(positionDiff);
        
        if (checkDist <= slowingRadius)
        {
            Vector3 vectVelocity = Vector3.Normalize(positionDiff) * (mySpeed * checkDist / slowingRadius);
            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);

            Vector3 mySteering = vectVelocity - myRb.velocity;

            Vector3.ClampMagnitude(mySteering, maxForce);

            myRb.AddForce(mySteering);

            Debug.Log(mySteering);
        }
        else
        {
            Vector3 vectVelocity = Vector3.Normalize(landingPoint.position - transform.position) * mySpeed;

            vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);
            Vector3 mySteering = vectVelocity - myRb.velocity;

            Vector3.ClampMagnitude(mySteering, maxForce);

            myRb.AddForce(mySteering);
        }
    }

    void SpawnUnit()
    {
        if (maxSpawns >= 1)
        {
            spawnCountdown -= Time.deltaTime;

            if (spawnCountdown <= 0)
            {
                maxSpawns--;
                Instantiate(enemyUnit, unitSpawnPoint.transform.position, Quaternion.identity);
                spawnCountdown = maxSpawnTimer;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
