using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionCheck : MonoBehaviour
{   
    //Using Capsule Collider instead of box to reduce errors with detecting walls, grounds, and ceilings
    public CapsuleCollider2D capsuleCollider;
    public ContactFilter2D contactFilter;
    public float wallDistance = 0.1f;
    public float ceilingDistance = 0.05f;
    public float groundDistance = 0.02f;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private bool onWall;
    [SerializeField] private bool onCeiling;
    RaycastHit2D[] groundHit = new RaycastHit2D[5];
    RaycastHit2D[] wallHit = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHit = new RaycastHit2D[5];
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Awake()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        capsuleCollider = rb.GetComponent<CapsuleCollider2D>();
        animator = rb.GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       IsGrounded = capsuleCollider.Cast(Vector2.down, contactFilter, groundHit, groundDistance) > 0;
       OnWall = capsuleCollider.Cast(wallDirection, contactFilter, wallHit, wallDistance) > 0;
       OnCeiling = capsuleCollider.Cast(Vector2.up, contactFilter, ceilingHit, ceilingDistance) > 0 ;
    }

    private Vector2 wallDirection => gameObject.transform.localScale.x > 0 ? Vector2.right :Vector2.left;

    public bool IsGrounded
    {
        get{
            return isGrounded;
        }
        set
        {
            isGrounded = value;
            animator.SetBool(Animations.isGrounded, value);
        }
    }
    public bool OnWall
    {
        get
        {
            return onWall;
        }
        set
        {
            onWall = value;
            animator.SetBool("onWall", value);

        }
    }
    public bool OnCeiling
    {
        get
        {
            return onCeiling;
        }
        set
        {
            onCeiling = value;
            animator.SetBool("onCeiling", value);

        }
    }
}
