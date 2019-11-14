using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMe : MonoBehaviour
{
    public LayerMask collisionLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            var cols = Physics.OverlapSphere(this.transform.position, 3, collisionLayer);
            if (cols.Length>0) {
                Destroy(cols[0].gameObject); 
            }
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(this.transform.position, 1);
    }
}
