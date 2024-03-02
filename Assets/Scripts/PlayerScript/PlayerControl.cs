using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;

public class PlayerController : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody;
    public Animator animator;
    public Vector2 walking_Velocity;
    private bool isMoving = false;
    private bool isRunning = false;
    private bool facingRight = true;
    private bool isAttack = false;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask isItGround;
    [SerializeField]public float runSpeed = 9.0f;
    [SerializeField]public float moveSpeed = 5.0f;
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
        Move();
        animator.SetFloat(Animations.yDirection, rigidBody.velocity.y);
    }
    void Update()
    {   
        //checks if character is on ground
        //isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, isItGround);
        //Jump();
        //Run();
        //Attack();

     }

    //Sets walking animation if walking
    public bool IsMoving {  get { return isMoving; } set { isMoving = value;
                animator.SetBool(Animations.isMoving, value);
            } }
    //Sets running animation if running
    public bool IsRunning { get { return isRunning; } set { isRunning = value;
                animator.SetBool(Animations.isRunning, value);
            } }

    //Walking
    public void Move()
    {
        rigidBody.velocity = new Vector2(walking_Velocity.x * WalkOrRun, rigidBody.velocity.y);
        //animator.SetFloat("walk_speed", Mathf.Abs(rigidBody.velocity.x));
        //if(rigidBody.velocity.x < 0f)
       // {
            //spriteRenderer.flipX = true;
       // }
        //else if (rigidBody.velocity.x > 0f){
          //  spriteRenderer.flipX = false;
        //}
    }

    public float WalkOrRun
    {
        get
        {
            if (IsMoving)
            {
                if (IsRunning)
                {
                    return runSpeed;
                }
                else
                {
                    return moveSpeed;
                }
            }
            else
            {
                return 0;
            }
        }
    }
    //Sets which direction the character is facing
    public void setDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0f && !FacingRight)
        {
            FacingRight = true;
        }else if (moveInput.x < 0f && FacingRight)
        {
            FacingRight = false;
        }
        
    }
    public bool FacingRight
    {
        get
        {
            return facingRight;
        }
        set
        {
            if(facingRight != value)
            {
                //Reverses the local scale of the object to the right
                transform.localScale *= new Vector2(-1, 1);
            }
            facingRight = value;
        }
    }

    //Obtains information on user input, then sets the value of IsMoving
    public void OnMove(InputAction.CallbackContext context)
    {
        walking_Velocity = context.ReadValue<Vector2>();
        IsMoving = walking_Velocity != Vector2.zero;
        setDirection(walking_Velocity);
    }
    //Checks if the button is pressed (L Shift), then sets then value of IsRunning
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
    public void onJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {

        }
    }
}
