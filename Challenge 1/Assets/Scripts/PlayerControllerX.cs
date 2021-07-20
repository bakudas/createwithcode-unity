using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject planeHelice;
    public float speed;
    private float rotationSpeed;
    private float verticalInput = 30;
    private bool isTurned = false; 

    public Animator animator;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        //verticalInput = Input.GetAxis("Vertical");
        //float horizontalInput = Input.GetAxis("Horizontal");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(Vector3.right, verticalInput);
        }
        

        // tilt the plane up/down based on up/down arrow keys
        
        //transform.Rotate(Vector3.forward, horizontalInput);
        
        // rotate the propiller
        planeHelice.transform.Rotate(Vector3.back, speed * 10);
    }

}
