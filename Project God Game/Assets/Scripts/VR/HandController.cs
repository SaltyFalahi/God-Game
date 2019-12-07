using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public enum Hand
    {
        Right, Left
    }

    public Hand hand;

    public LayerMask mask;

    public List<GameObject> pickables;

    public bool emptyHanded;

    void Start()
    {
        emptyHanded = true;
    }

    void Update()
    {
        if (pickables.Count > 0)
        {
            if (pickables[0].gameObject.GetComponentInParent<Pickable>())
            {
                if (emptyHanded)
                {
                    pickables[0].SendMessage("OnHandHover", this);
                }

                switch (hand)
                {
                    case Hand.Right:
                        if (Input.GetButtonDown("XRI_Right_TriggerButton"))
                        {
                            pickables[0].SendMessage("OnHandTrigger", this);

                            emptyHanded = false;
                        }

                        if (Input.GetButtonUp("XRI_Right_TriggerButton"))
                        {
                            pickables[0].SendMessage("OnHandTriggerReleased", this);

                            emptyHanded = true;
                        }

                        break;

                    case Hand.Left:
                        if (Input.GetButton("XRI_Left_TriggerButton") || Input.GetKey(KeyCode.X))
                        {
                            pickables[0].SendMessage("OnHandTrigger", this);

                            emptyHanded = false;
                        }
                        if (Input.GetButtonUp("XRI_Left_TriggerButton"))
                        {
                            pickables[0].SendMessage("OnHandTriggerReleased", this);

                            emptyHanded = true;
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        pickables.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        pickables.Remove(other.gameObject);
    }
}
