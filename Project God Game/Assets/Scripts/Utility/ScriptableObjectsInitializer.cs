using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectsInitializer : MonoBehaviour
{
    public List<IntVariable> resources = new List<IntVariable>();

    public List<Request> requests = new List<Request>();

    private void Awake()
    {
        for (int i = 0; i < resources.Count; i++)
        {
            resources[i].Value = 0;
        }

        for (int i = 0; i < requests.Count; i++)
        {
            requests[i].count = 0;
            requests[i].type = null;
            requests[i].completed = false;
        }
    }
}
