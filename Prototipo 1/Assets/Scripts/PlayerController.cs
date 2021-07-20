using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float _speed = 10f;
    // public float turnSpeed = 10f;
    

    // Update is called once per frame
    void Update()
    {
        // Player's Inputs
        float steer = Input.GetAxis("Horizontal");
        float accel = Input.GetAxis("Vertical");
        
        // Aprendendo a comentar os codigos doidos man
        //transform.Translate(0,0, 1);
        transform.Translate(Vector3.forward * (Time.deltaTime * _speed * accel));
        // turning the player
        //transform.Translate(Vector3.right * (Time.deltaTime * turnSpeed * steer));
        transform.Rotate(Vector3.up, steer);
    }
}
