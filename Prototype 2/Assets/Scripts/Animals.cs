using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour
{
    
    public float speed = 20f;
    

    // Update is called once per frame
    void Update()
    {
        // Animal runs foward
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        
        if (transform.position.z < -20) Destroy(gameObject);
    }
}
