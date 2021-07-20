using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodProjectile : MonoBehaviour
{

    public float speed = 20f;

    // Update is called once per frame
    void Update()
    {
        // fire food projectile
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        
        if (transform.position.z > 35) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
