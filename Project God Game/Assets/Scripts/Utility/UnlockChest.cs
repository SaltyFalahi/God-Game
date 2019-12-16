using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockChest : MonoBehaviour
{
    public Animator anim;

    public GameObject building;
    public GameObject prefab;

    public Transform stored;

    public bool locked;

    public string keyType;

    void Start()
    {
        anim = GetComponent<Animator>();
        locked = true;
    }

    void Update()
    {
        if (building == null && !locked)
        {
            building = Instantiate(prefab);
            building.transform.position = stored.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(keyType))
        {
            anim.SetBool("Unlocked", true);
            locked = false;
            Destroy(other.gameObject);
        }
    }
}