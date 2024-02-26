using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;


public class PlayerController : MonoBehaviour
{
    [SerializeField]public float moveSpeed = 5.0f;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public Vector2 walking_Velocity;
    private bool isMoving = false;
    public bool IsMoving {  get { return isMoving; } set { isMoving = value;
            animator.SetBool("isMoving", value);
        } }
    private bool isRunning = false;
    public bool IsRunning { get { return isRunning; } set { isRunning = value;
            animator.SetBool("isRunning", value);
        } }
    private bool isJumping;
    private bool isGrounded;
  
    private bool isAttack = false;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask isItGround;
    [SerializeField]public float runspeed = 9.0f;
    public SpriteRenderer spriteRenderer;
    [SerializeField]public float jumpForce = 7f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Walk();

    }
    void Update()
    {   
        //checks if character is on ground
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, isItGround);
        //Jump();
        //Run();
        //Attack();

     }

    //Walking
    public void Walk()
    {
        rigidBody.velocity = new Vector2(walking_Velocity.x * moveSpeed, rigidBody.velocity.y);
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
    //public void Jump()
    //{
      //  if (Input.GetButtonDown("Jump") && isGrounded)
        //{
          //  animator.SetBool("isJumping", true);
            //isJumping = true;
            //rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
            //isGrounded = false;
        //}
        //if (isGrounded)
        //{
          //  isJumping = false;
            //animator.SetBool("isJumping", false);
        //}
        //else
        //{
          //  animator.SetBool("isJumping", true);
        //}
    //}

    //Run
   // public void Run()
    //{
        //Run
     //   if (Input.GetKey(KeyCode.LeftShift))
       // {
         //   rigidBody.velocity = new Vector2(moveSpeed * runspeed, rigidBody.velocity.y);
           // isRunning = true;
            //animator.SetBool("isRunning", true);
        //}
        //else
        //{
          //  isRunning = false;
            //animator.SetBool("isRunning", false);
        //}
    //}
    //public void Attack()
    //{
        //if (Input.GetKey(KeyCode.J) && !isAttack)
        //{
            //isAttack = true;
          //  animator.SetBool("isAttack_1", true);
        //}
        //else
        //{
            //isAttack = false;
          //  animator.SetBool("isAttack_1", false);
        //}

        //if(Input.GetKey(KeyCode.K) && !isAttack)
        //{
            //isAttack = true;
          //  animator.SetBool("isAttack_2", true);
        //}
        //else
        //{
            //isAttack = false;
          //  animator.SetBool("isAttack_2", false);
        //}
        //if (Input.GetKey(KeyCode.L) && !isAttack)
        //{
            //isAttack = true;
          //  animator.SetBool("isAttack_3", true);
        //}
        //else
        //{
            //isAttack = false;
          //  animator.SetBool("isAttack_3", false);
        //}
    //}
    public void OnMove(InputAction.CallbackContext context)
    {
        walking_Velocity = context.ReadValue<Vector2>();
        IsMoving = walking_Velocity != Vector2.zero;
    }
    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        }
        else if (context.canceled)
        {
            IsRunning = false;
        }
    }
}
