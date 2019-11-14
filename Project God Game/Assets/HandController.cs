using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("XRI_Left_TriggerButton"))
        {
            var cols = Physics.OverlapSphere(this.transform.position, 3);
            if (cols.Length>0)
            {
                if (cols[0].gameObject.GetComponentInParent<Pickable>())
                {
                    cols[0].transform.parent = this.transform;
                     
                }
            }
        }
    }
}
