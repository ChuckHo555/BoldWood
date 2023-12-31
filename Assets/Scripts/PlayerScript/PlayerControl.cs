using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public Vector2 walking_Velocity;
    private bool isJumping;
    private bool isGrounded;
    private bool isRunning;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask isItGround;
    public float runspeed = 8.0f;
    public float directionX;
    public SpriteRenderer spriteRenderer;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        spriteRenderer.flipX = rigidBody.velocity.x < 0f;
    }

    //Jump
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            animator.SetBool("isJumping", true);
            isJumping = true;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 7f);
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
