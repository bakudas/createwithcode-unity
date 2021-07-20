using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private float jumpForce = 300f;
    private int ballCount = 0;
    private float vInput;
    private float hInput;
    private ThrowSnowBall _throwSnowBall;


    public int BallCount
    {
        get => ballCount;
        set => ballCount = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _throwSnowBall = GetComponent<ThrowSnowBall>();
    }

    // Update is called once per frame
    void Update()
    {
        // get input
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");

        // player movement
        transform.Translate(Vector3.forward * (speed * vInput * Time.deltaTime));
        transform.Translate(Vector3.right * (speed * hInput * Time.deltaTime));
        
        transform.LookAt(_throwSnowBall.WorldPosition);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * jumpForce);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coletavel"))
        {
            Destroy(other.gameObject);
            BallCount += 1;
        }
    }
}
