using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    

    private Rigidbody rb;

    float timeframe;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 300);
    }
	
	// Update is called once per frame

}
