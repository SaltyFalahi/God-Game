using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockChest : MonoBehaviour
{
    public Animator anim;

    public GameObject building;

    public Transform stored;

    public string keyType;

    void Start()
    {
        anim = GetComponent<Animator>();

        building.transform.position = stored.position;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(keyType))
        {
            anim.SetBool("Unlocked", true);
        }
    }
}
