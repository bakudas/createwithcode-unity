﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float turnSpeed = 2f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right,  turnSpeed);    
    }
}
