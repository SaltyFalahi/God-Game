using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShader : MonoBehaviour
{
    public float waveAmplitude;
    public float waveSpeed;
    public float waveFrequency;

    Mesh myMesh;

    Vector3[] verts;

    float waterHeight = 10;
    float waterWidth = 500;

    // Start is called before the first frame update
    void Start()
    {
        myMesh = GetComponent<MeshFilter>().mesh;
    }

    // Update is called once per frame
    void Update()
    {
        verts = myMesh.vertices;

        for (int i = 0; i < verts.Length; i++)
        {
            verts[i].y += Mathf.Sin(Time.deltaTime * waveSpeed + (verts[i].x * verts[i].z * waveFrequency) * waveAmplitude);
        }
    }
}
