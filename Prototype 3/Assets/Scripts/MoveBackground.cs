using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    // public vars
    public float speed = 10;
    public Vector3 startPos = new Vector3(109f, 0f, 0f);
    public GameObject[] background;
    
    // private vars
    private PlayerController player;

    private void Start()
    {
        // setar playerController na variavel player
        player = FindObjectOfType<PlayerController>();
   
    }

    // Update is called once per frame
    void Update()
    {
        // checa se o jogo tá valendo
        if (player.IsPlaying)
        {
            // move o fundo para a esquerda
            transform.Translate(Vector3.left * (speed * Time.deltaTime)); 
        }
        
        
        // checa se o fundo 01 atinge um determinado ponto
        if (background[0].transform.position.x < -115)
        {
            // reposiciona o fundo 01
            background[0].transform.position = startPos;
        }  
        
        // checa se o fundo 02 atinge um determinado ponto
        if (background[1].transform.position.x < -115)
        {
            // reposiciona o fundo 01
            background[1].transform.position = startPos;
        }
        
    }
}
