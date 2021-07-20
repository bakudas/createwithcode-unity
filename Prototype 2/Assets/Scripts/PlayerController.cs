using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 20f;

    public GameObject food;
    
    private float vInput;
    private float hInput;
    private float xRange = 13f;
    private float zPos = -3f;
    private Animator _animator;
    

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // get input
        //vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        
        // move player
        transform.Translate(Vector3.right * (speed * Time.deltaTime * hInput));
        //transform.Translate(Vector3.forward * (speed * Time.deltaTime * vInput));
        _animator.SetFloat("Speed_f", Mathf.Abs(hInput));

        // bounds
        if (transform.position.x <= -xRange) transform.position = new Vector3(-xRange, 0, zPos);
        if (transform.position.x >= xRange) transform.position = new Vector3(xRange, 0, zPos);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(food, transform.position, Quaternion.identity);
        }


    }
}
