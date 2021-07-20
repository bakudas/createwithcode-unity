using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThrowSnowBall : MonoBehaviour
{
    
    public GameObject snowball;
    public Transform spawnPoint;
    private float forceToThrow = 100f;
    private Vector3 impulsoSentido = new Vector3(0,1,-1 );
    private Vector3 worldPosition;

    public Vector3 WorldPosition
    {
        get => worldPosition;
        set => worldPosition = value;
    }

    public float ForceToThrow
    {
        get => forceToThrow;
        set => forceToThrow = value;
    }


    // Update is called once per frame
    void Update()
    {
        Plane plane = new Plane(Vector3.up, 0);
        
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            WorldPosition = ray.GetPoint(distance);
        }

        // press and hold de throw snowball with more force
        if (Input.GetButton("Fire1"))
        {
            if (ForceToThrow < 600)
            {
                ForceToThrow += 3;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            // instantiate some snowballs
            Instantiate(snowball, spawnPoint.position, spawnPoint.rotation);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(WorldPosition, new Vector3(.5f, .5f, .5f));

    }
}
