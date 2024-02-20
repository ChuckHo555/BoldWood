using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;


public class PlayerController : MonoBehaviour
{
    [SerializeField]public float moveSpeed = 2.0f;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public Vector2 walking_Velocity;
    private bool isJumping;
    private bool isGrounded;
    private bool isRunning;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask isItGround;
    [SerializeField]public float runspeed = 8.0f;
    public float directionX;
    public SpriteRenderer spriteRenderer;
    [SerializeField]public float jumpForce = 7f;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Walk();

    }
    void Update()
    {   
        //checks if character is on ground
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, isItGround);
        Jump();
        Run();

     }

    //Walking
    public void Walk()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(directionX * moveSpeed, rigidBody.velocity.y);
        animator.SetFloat("walk_speed", Mathf.Abs(rigidBody.velocity.x));
        if(rigidBody.velocity.x < 0f)
        {
            spriteRenderer.flipX = true;
        }
        else if (rigidBody.velocity.x > 0f){
            spriteRenderer.flipX = false;
        }
    }

    //Jump
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetBool("isJumping", true);
            isJumping = true;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            isGrounded = false;
        }
        if (isGrounded)
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }
    }

    //Run
    public void Run()
    {
        //Run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rigidBody.velocity = new Vector2(moveSpeed * runspeed, rigidBody.velocity.y);
            isRunning = true;
            animator.SetBool("isRunning", true);
        }
        else
        {
            isRunning = false;
            animator.SetBool("isRunning", false);
        }
    }
}
