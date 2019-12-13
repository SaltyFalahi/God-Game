﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform leftHand;
    public Transform rightHand;
    public Transform head;

    public float speed;
    public float timer;

    Vector3 currentHandPos;
    Vector3 pastHandPos;
    Vector3 direction;

    float handDist;
    float pastHandDist;
    float totalHandDist;
        
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("XRI_Left_TriggerButton") && Input.GetButton("XRI_Right_TriggerButton") && head.position.y >= 10)
        {
            handDist = Vector3.Distance(leftHand.position, rightHand.position);

            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                totalHandDist = handDist - pastHandDist;
                if (totalHandDist > .1f)
                {
                    Debug.Log("zoom in");
                    transform.Translate(head.forward * totalHandDist * Time.deltaTime * speed);
                }
                else if (totalHandDist < -.1f)
                {
                    Debug.Log("zoom out");
                    transform.Translate(head.forward * totalHandDist * Time.deltaTime * speed);
                }

                pastHandDist = Vector3.Distance(leftHand.position, rightHand.position);
                timer = .01f;
            }
        }
        else
        {
            pastHandDist = Vector3.Distance(leftHand.position, rightHand.position);
        }

        //if (Input.GetButton("XRI_Left_GripButton"))
        //{
        //    currentHandPos = leftHand.position;

        //    timer -= Time.deltaTime;

        //    if (timer <= 0)
        //    {
        //        direction = (pastHandPos - currentHandPos).normalized;

        //        transform.Translate(direction * Time.deltaTime * speed);

        //        pastHandPos = leftHand.position;
        //        timer = .01f;
        //    }
        //}

        //if (Input.GetButton("XRI_Right_GripButton"))
        //{
        //    currentHandPos = rightHand.position;

        //    timer -= Time.deltaTime;

        //    if (timer <= 0)
        //    {
        //        direction = (pastHandPos - currentHandPos).normalized;

        //        transform.Translate(direction * Time.deltaTime * speed);

        //        pastHandPos = rightHand.position;
        //        timer = .01f;
        //    }
        //}
    }
}