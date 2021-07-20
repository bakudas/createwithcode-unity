using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtStart : MonoBehaviour
{
    public float delayTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delayTime);
    }

}
