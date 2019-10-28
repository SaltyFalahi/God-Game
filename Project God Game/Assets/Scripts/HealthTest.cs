using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTest : MonoBehaviour
{
    public float health;
    public float arrowDamage;
    public float bombDamage;
    public float blastRadius;

    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "arrow")
        {
            health -= arrowDamage;
        }

        if (other.gameObject.tag == "bomb")
        {
            health -= bombDamage;
        }
    }
}