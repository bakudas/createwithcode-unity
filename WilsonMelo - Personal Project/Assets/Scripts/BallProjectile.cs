using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProjectile : MonoBehaviour
{
    private float force = 350f;
    private float destroyTime = 2.0f;
    private Vector3 impulso = new Vector3(0,1,1 );
    private Rigidbody rb;
    private ThrowSnowBall _throwSnowBall;

    public float Force
    {
        get => force;
        set => force = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _throwSnowBall = FindObjectOfType<ThrowSnowBall>();
        
        // set the rigidbody
        rb = GetComponent<Rigidbody>();
        
        // set force by press and hold the space button
        Force = FindObjectOfType<ThrowSnowBall>().ForceToThrow;

        // call method to throw snowballs
        ThrowBall(Force);
        
        // destroy snowball
        Destroy(gameObject, destroyTime);
        
        // set the deaful force
        FindObjectOfType<ThrowSnowBall>().ForceToThrow = 100f;

    }

    public void ThrowBall(float force)
    {
        // apply force and throw snowballs
        rb.AddRelativeForce(impulso * force);
    }

    
}
