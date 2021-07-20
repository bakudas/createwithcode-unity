using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    //public vars
    public float speed = 10.0f;
    public float jumpForce = 20.0f;
    public float jumpCooldown;
    public float jumpSustain = 0.5f;
    public float dashForce = 5.0f;
    public float dashCooldown = 0.5f;
    public GameObject dashFxDust;
    public Transform playerFeet;
    public float checkRadius;
    public LayerMask theGround;

    //private vars
    private bool isJumping;
    private bool isGrounded;
    private float hInput;
    private Rigidbody2D rb2D;
    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        // get rigidbody
        rb2D = GetComponent<Rigidbody2D>();
        
        // get Animator
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // captura o input
        hInput = Input.GetAxis("Horizontal");
        
        // move o jogador
        transform.Translate(Vector2.right * (speed * Time.deltaTime * Mathf.Abs(hInput)));
        _animator.SetFloat("Speed_f", Mathf.Abs(hInput));

        // flip sprite
        FlipSprite(hInput);
        
        // checa se o player está no chão
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, checkRadius, theGround);
        
        // mecanica de pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            jumpCooldown = jumpSustain;
            PlayerJump(jumpForce, true);
            
        }
        // se apertar mais o botão o boneco vai pular mais alto
        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpCooldown > 0)
            {
                PlayerJump(jumpForce, false);
                jumpCooldown -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
        
        // mecanica do Dash
        var timerDashCooldown = (dashCooldown > 0 ) ? dashCooldown -= Time.deltaTime : dashCooldown = 0;

        if (Input.GetButtonDown("Dash"))
        {
            if (dashCooldown <= 0 )
            {
                PlayerDash(dashForce, hInput); 
                dashCooldown = 0.5f; // reseta o cooldown
            }
        }
        
        // Ataque
        if (Input.GetButtonDown("Attack1"))
        {
            _animator.SetTrigger("Atk01");
        }
        
    }

    // metodo do dash do jogador
    private void PlayerDash(float force, float input)
    {
        // realiza uma força(impulso) no eixo X no rigidbody para fazer o dash
        rb2D.AddForce(Vector2.right * (force * input), ForceMode2D.Impulse);
        
        // animação toca baseado se o player estiver em movimento
        if (input != 0)
        {
            _animator.SetTrigger("Dash");
            Instantiate(dashFxDust, transform.position, transform.rotation);
        }

        
        
    }

    // metodo do pulo do jogador
    private void PlayerJump(float force, bool anim)
    {
        // realiza uma força(impulso) no eixo Y no rigidbody para fazer o pulo
        //rb2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        rb2D.velocity = Vector2.up * force;
        
        if (anim) _animator.SetTrigger("Jump");
    }
    
    // Flipa a sprite para a orientação do jogador
    private void FlipSprite(float input)
    {
        if (input > 0) transform.localRotation = new Quaternion(0, 0, 0, 0);
        if (input < 0) transform.localRotation = new Quaternion(0, 180, 0, 0);
    }
    
    
}





