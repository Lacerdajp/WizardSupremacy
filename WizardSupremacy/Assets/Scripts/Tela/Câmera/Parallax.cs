using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float StartPos;

    private Transform cam;

    public float ParallaxEffect;

    void Start()
    {
        StartPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    void Update()
    {
        float RePos = cam.transform.position.x * (1 - ParallaxEffect);
        float Distance = cam.transform.position.x * ParallaxEffect;

        transform.position = new Vector3(StartPos + Distance, transform.position.y, transform.position.z);  

        if(RePos > StartPos + length)
        {
            StartPos += length;
        }
        else if(RePos < StartPos - length)
        {
            StartPos -= length;
        }
    }
}
