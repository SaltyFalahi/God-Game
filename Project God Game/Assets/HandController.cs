using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Hand
{
    Right, Left
}

public class HandController : MonoBehaviour
{
    public Hand hand;
    public bool emptyHanded;
    public GameObject current;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        emptyHanded = true;
    }

    // Update is called once per frame
    void Update()
    {





        var cols = Physics.OverlapSphere(this.transform.position, 1, mask);
      
        if (cols.Length > 0)
        {
            if (cols[0].gameObject.GetComponentInParent<Pickable>())
            {
                Debug.Log("something is being hovered on");
                if (emptyHanded)
                {
                    cols[0].SendMessage("OnHandHover", this);
                }
                switch (hand)
                {
                    case Hand.Right:
                        if (Input.GetButtonDown("XRI_Right_TriggerButton"))
                        {


                            cols[0].SendMessage("OnHandTrigger", this);

                            emptyHanded = false;
                        }

                        if (Input.GetButtonUp("XRI_Right_TriggerButton"))
                        {


                            cols[0].SendMessage("OnHandTriggerReleased", this);
                            emptyHanded = true;
                        }

                        break;
                    case Hand.Left:
                        if (Input.GetButton("XRI_Left_TriggerButton") || Input.GetKey(KeyCode.X))
                        {
                            Debug.Log("xerrrrrx");
                            cols[0].SendMessage("OnHandTrigger", this);
                            emptyHanded = false;
                        }
                        if (Input.GetButtonUp("XRI_Left_TriggerButton"))
                        {
                            cols[0].SendMessage("OnHandTriggerReleased", this);
                            emptyHanded = true;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

    }


}
