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
    [SerializeField]private bool onGround = true;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask isItGround;
    [SerializeField]public float runSpeed = 9.0f;
    [SerializeField]public float moveSpeed = 5.0f;
    [SerializeField]public float jumpForce = 8.0f;
    [SerializeField] public float airSpeed = 3.0f;
    DirectionCheck directionCheck;
    Health damageable;


    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        directionCheck = GetComponent<DirectionCheck>();
        damageable = GetComponent<Health>();
    }

    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (!damageable.WasHit)
        {
             Move();
        }
       
        animator.SetFloat(Animations.yDirection, rigidBody.velocity.y);

        //checks if character is on ground
        onGround = Physics2D.OverlapCircle(feetPos.position, checkRadius, isItGround);

         
    }
    void Update()
    {   

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
    }

    public float WalkOrRun
    {
        get
        {
            if (YesMove)
            {  if (IsMoving)
                {
                    if (onGround) { 
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
                         return airSpeed;
                      }
                    }
               else
                {
                    return 0;
                }

            }
            else
            {
                //cannot move if moving is locked
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

    public bool YesMove
    {
        get
        {
            return animator.GetBool(Animations.yesMove);
        }
    }
    public bool IsAlive
    {
        get
        {
            return animator.GetBool("isAlive");
        }
    }

    //Obtains information on user input, then sets the value of IsMoving
    public void OnMove(InputAction.CallbackContext context)
    {
        walking_Velocity = context.ReadValue<Vector2>();
        if (IsAlive)
        {
            IsMoving = walking_Velocity != Vector2.zero;
            setDirection(walking_Velocity);
        }
        else
        {
            IsMoving = false;
        }
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
        if (context.started && onGround && YesMove)
        {
            animator.SetTrigger(Animations.Jump);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }
    }
    public void onAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(Animations.Attack);
        }
    }
    public void OnHit(int damage, Vector2 knockback)
    {
        rigidBody.velocity = new Vector2(knockback.x, rigidBody.velocity.y+knockback.y);
    }
    
        
    
}
