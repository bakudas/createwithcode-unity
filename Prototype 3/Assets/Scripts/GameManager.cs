using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // public vars
    public GameObject gameOverMenu;
    
    // private vars
    private PlayerController _playerController;
    
    private void Start()
    {
        // seta o player controller 
        _playerController = FindObjectOfType<PlayerController>();

        // esconde o menu de game over
        gameOverMenu.SetActive(false);
    }

    
    private void Update()
    {
        if (!_playerController.IsPlaying)
        {
            gameOverMenu.SetActive(true);
        }
    }

    
    public void ChageScene(string _scene)
    {
        // carrega novamente a cena do jogo
        SceneManager.LoadScene(_scene);
    }
}
