using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Transform landingPoint;

    public float mySpeed;
    public float maxForce;

    Rigidbody myRb;

    // Start is called before the first frame update
    void Awake()
    {
        myRb = GetComponent<Rigidbody>();
        //landingPoint = FindObjectOfType<GameOb>();
    }

    // Update is called once per frame
    void Update()
    {

        Seek();
    }

    void Seek()
    {
        Vector3 vectVelocity = Vector3.Normalize(landingPoint.position - transform.position) * mySpeed;

        vectVelocity = new Vector3(vectVelocity.x, 0, vectVelocity.z);

        Vector3 mySteering = vectVelocity - myRb.velocity;

        Vector3.ClampMagnitude(mySteering, maxForce);

        myRb.AddForce(mySteering);
    }
}
