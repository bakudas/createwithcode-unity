using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{

    public enum TipoColetavel
    {
        Moeda,
        Checkpoint,
        Tempo
    }

    
    public TipoColetavel item;
    public int score = 10;

    private GameManager _gameManager;


    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (item)
            {
                case TipoColetavel.Moeda:
                    Destroy(gameObject);
                    _gameManager.Score = score;
                    Debug.Log(_gameManager.Score);
                    break;
                case TipoColetavel.Checkpoint:
                    break;
                case TipoColetavel.Tempo:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    
}
