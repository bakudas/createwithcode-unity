using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float cooldown = 2f;

    // Update is called once per frame
    void Update()
    {
        if (cooldown > 0) cooldown -= Time.deltaTime;

        if (cooldown < 0)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                cooldown = 2f;
            } 
        }
        Debug.Log(cooldown);
        
    }
}
