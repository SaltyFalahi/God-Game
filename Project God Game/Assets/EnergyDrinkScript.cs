using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrinkScript : MonoBehaviour
{
    float dotProduct;
    //public GameObject liquidParticle;
    ParticleSystem ps;
    LayerMask colLayer;
    void Start()
    {

       
            ps = GetComponentInChildren<ParticleSystem>();
  
       
    }

    // Update is called once per frame
    void Update()
    {
        dotProduct = Vector3.Dot(Vector3.up, transform.up);
        if (dotProduct < -.4f)
        {
            if (ps != null)
            {
                ps.Play();
            }
            else
            {
                ps = GetComponentInChildren<ParticleSystem>();
            }
        }
        else
        {
            if (ps != null)
            {
                ps.Stop();
            }
            else
            {
                ps = GetComponentInChildren<ParticleSystem>();
            }
        }
        RaycastHit hit;
        if(Physics.BoxCast(transform.position, Vector3.one, Vector3.down,out hit ,Quaternion.identity, 50, colLayer)) 
        {

        }
    }
}
