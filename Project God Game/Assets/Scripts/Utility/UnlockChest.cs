using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockChest : MonoBehaviour
{
    public Animator anim;

    public GameObject building;
    public GameObject prefab;

    public Transform stored;

    public string keyType;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (building == null)
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
            gameObject.GetComponent<Pickable>().enabled = true;
            Destroy(other);
        }
    }
}