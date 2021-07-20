using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    // variáveis públicas
    public float jumpForce = 18;
    public float gravityModifier = 3.5f;
    public ParticleSystem dustParticle;
    public ParticleSystem explosionParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    
    // variáveis privadas
    public bool isGrounded;
    private bool isPlaying;
    private Rigidbody rb;
    private Animator _animator;
    private AudioSource playerAudio;
    
    // props
    public bool IsGrounded
    {
        get => isGrounded;
        set => isGrounded = value;
    }

    public bool IsPlaying
    {
        get => isPlaying;
        set => isPlaying = value;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        // inicia algumas variáveis
        IsPlaying = true;
        IsGrounded = true;
        
        // seta o componente AudioSource
        playerAudio = GetComponent<AudioSource>();
        
        // encontrar o componente e setar na variável
        rb = GetComponent<Rigidbody>();
        
        // ajuste fino da física
        Physics.gravity *= gravityModifier;

        // encontra o componente animator e seta na variável
        _animator = GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {

        // checa se o espaço é pressionado, se o jogador está no chão e se o jogo está valendo
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded && IsPlaying)
        {
            // aplica força e realizar um jump 
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            
            // ground check
            IsGrounded = false;
            
            // seta animação do pulo
            _animator.SetTrigger("Jump_trig");

            // para as particulas
            dustParticle.Stop();
            
            // play audio jump
            playerAudio.PlayOneShot(jumpSound, 0.75f);
        }

        
    }
    

    private void OnCollisionEnter(Collision other)
    {

        // checa a colisão com o chão
        if (other.collider.CompareTag("Ground"))
        {
            // player está no chão
            IsGrounded = true;
            
            // toca as particulas de poeira
            dustParticle.Play();
        }
        
        // checa a colisão com obstaculo
        else if (other.collider.CompareTag("Obstacle"))
        {
            // game over
            IsPlaying = false;

            // printa o gameover
            Debug.Log("Game Over");
            
            // seta animação de derrota
            _animator.SetBool("Death_b", true);
            
            // toca a particula de explosão
            explosionParticle.Play();
            
            // para as particulas de poeira
            dustParticle.Stop();
            
            // play crash sound
            playerAudio.PlayOneShot(crashSound, 0.75f);
        }
    }
}
