using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWolfScript : MonoBehaviour
{
    public float walkSpeed = 3f;
    Rigidbody2D rigibody;
    public enum WalkDirection {  Right, Left };
    private WalkDirection walkdirection;
    private Vector2 walkVector = Vector2.right;
    DirectionCheck directionCheck;
    public DetectionRange attackRange;
    public bool targetDetected = false;
    Animator animator;
    private float delaySpeed = 0.1f;
    Health damageable;
    private float cooldownTimer;
    public DetectionRange cliffDetection;

    public WalkDirection _WalkDirection
    {
        get { return walkdirection; }
        set
        {
            if (walkdirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == WalkDirection.Right)
                {
                    walkVector = Vector2.right; 
                }
                else if(value == WalkDirection.Left)
                {
                    walkVector = Vector2.left; 
                }
            }
            walkdirection = value;
        }
    }
    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
        directionCheck = GetComponent<DirectionCheck>();
        animator = GetComponent<Animator>();
        damageable = GetComponent<Health>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (directionCheck.OnWall && directionCheck.IsGrounded)
        {
            FlipCharacter();
        }
        if (!damageable.WasHit)
        {
            if (YesMove)
            {
                rigibody.velocity = new Vector2(walkSpeed * walkVector.x, rigibody.velocity.y);
            }
            else
            {
                rigibody.velocity = new Vector2(Mathf.Lerp(rigibody.velocity.x, 0, delaySpeed), rigibody.velocity.y);
            }
        }
    }

    void FlipCharacter()
    {
        if(_WalkDirection == WalkDirection.Right)
        {
            _WalkDirection = WalkDirection.Left;
        }
        else if(_WalkDirection == WalkDirection.Left) 
        {
            _WalkDirection = WalkDirection.Right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TargetDetected = attackRange.detectedColliders.Count > 0;
        if(cooldownTimer > 0)
        {
            CooldownTimer -= Time.deltaTime;
        }
        
    }
    public bool TargetDetected
    {
        get
        {
            return targetDetected;
        }
        set
        {
            targetDetected= value;
            animator.SetBool("targetDetected", value);
        }
    }
    public bool YesMove
    {
        get
        {
            return animator.GetBool("yesMove");
        }
    }
    public void onHit(int damage, Vector2 knockback)
    {
        rigibody.velocity = new Vector2(knockback.x, rigibody.velocity.y - knockback.y);
    }

    public float CooldownTimer
    {
        get
        {
            return animator.GetFloat("cooldownTimer");
        }
        set
        {
            animator.SetFloat("cooldownTimer", Mathf.Max(value, 0));
        }
    }
    public void NoGroundDetected()
    {
        if (directionCheck.IsGrounded)
        {
            FlipCharacter();
        }
    }
}
