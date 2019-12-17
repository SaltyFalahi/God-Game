using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrinkScript : MonoBehaviour
{
    float dotProduct;
    //public GameObject liquidParticle;
    ParticleSystem ps;
    GameObject particleGO;
    public LayerMask colLayer;
    void Start()
    {

            particleGO = transform.GetChild(0).gameObject;
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
                RaycastHit hit;
                if (Physics.BoxCast(particleGO.transform.position, Vector3.one/6, Vector3.down, out hit, Quaternion.identity, 50, colLayer))
                {
                    Debug.Log(hit.collider.gameObject.name);
                }
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
    
    }
}
