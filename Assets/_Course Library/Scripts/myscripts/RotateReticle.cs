using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateReticle : MonoBehaviour
{
    public float rotationSpeed = 2.0f;
    public
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, rotationSpeed, 0.0f, Space.World);
        print("Rotating " + DateTime.Now.Second);
    }
}
