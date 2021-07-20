using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{

    // public vars
    public float speed;

    //private vars
    private PlayerController _player;
    
    // Update is called once per frame
    void Update()
    {
        
        // captura o componente playerController e seta na variável
        _player = FindObjectOfType<PlayerController>();
        
        // checa se o jogo tá valendo
        if (_player.IsPlaying)
        {
            // move o gameobject
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
         
        
        // checa a posição do objeto para destruir se passar do ponto
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
