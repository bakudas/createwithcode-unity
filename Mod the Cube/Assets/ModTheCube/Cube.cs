using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public Vector3 cubePosition = new Vector3(6, 7.82f, -0.50f );
    public float scaleFactor = 2f;
    public float rotatioSpeed = 10.0f;
    private Color cubeColor = Color.magenta;
    
    private Material material;
    
    void Start()
    {
        //set cube position
        transform.position = cubePosition;
        
        //set renderer to material
        material = Renderer.material;
        
    }
    
    void Update()
    {
        //modify scale
        transform.localScale = Vector3.one * scaleFactor;
        
        //adjust rotation
        transform.Rotate(Vector3.right * rotatioSpeed);
        
        //change material color
        material.color = cubeColor;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
    }

    private void ChangeColor()
    {
        float r = Random.Range(10, 255);
        float b = Random.Range(10, 255);
        float g = Random.Range(10, 255);
        float a = Random.Range(10, 255);
        
        Debug.Log(r + " " + g + " " + b);
        
        Color randColor = new Color(r, g, b);
        
        cubeColor =  randColor;
    }
}
