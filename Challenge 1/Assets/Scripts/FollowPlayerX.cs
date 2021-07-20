using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    public Vector3 cameraOffset = new Vector3(25, 2.5f, 0);

    
    // Update is called once per frame
    void Update()
    {
        transform.position = plane.transform.position + cameraOffset;
    }
}
