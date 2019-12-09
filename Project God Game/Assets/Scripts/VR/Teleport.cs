using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Camera camera;

    public GameObject cover;

	public float timeInDark;

    public bool isFading;

    private float timer;

    private void Start()
    {
        timer = timeInDark;
    }

    private void Update()
    {
        if (Input.GetButtonDown("XRI_Left_Primary2DAxisClick") && !isFading)
        {
            Debug.Log("Button");
            Shoot();
        }
    }

    private void Shoot()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform != null)
            {
                Debug.Log("Hit");
                cover.SetActive(true);
                isFading = true;
            }
        }

        if (isFading)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                Debug.Log("Timer");
                Vector3 newLocation = new Vector3(hit.point.x, 1, hit.point.z);
                transform.position = newLocation;
                cover.SetActive(false);
                isFading = false;
                timer = timeInDark;
            }
        }
    }
}
