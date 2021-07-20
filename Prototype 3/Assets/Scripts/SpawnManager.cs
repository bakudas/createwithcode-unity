using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
        
    // public vars
    public GameObject obstacle;
    
    // private vars
    private Vector3 spawnPos;
    private float spawnDelay = 2f;
    private float spawnRepeatRate = 2f;
    private PlayerController _player;
    
    // Start is called before the first frame update
    void Start()
    {
        // seta posição inicial para o spawn
        spawnPos = transform.position;
        
        // captura o componente playerController e seta na variavel
        _player = FindObjectOfType<PlayerController>();
        
        // faz a chama do método em intervalos de tempo
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnRepeatRate);
    }

    /// <summary>
    /// Spawna os obstáculos se o jogo estiver valendo
    /// </summary>
    private void SpawnObstacle()
    {
        // checa se o jogo tá valendo
        if (_player.IsPlaying)
        {
            // instancia o obstaculo na posição do spawner e com a orientação do proprio obstaculo
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
        
    }

}
