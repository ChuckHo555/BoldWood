using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{   
    //Using Capsule Collider instead of box to reduce errors with detecting walls, grounds, and ceilings
    public CapsuleCollider2D capsuleCollider;
    public ContactFilter2D contactFilter;
    public float groundDistance = 0.05f;
    [SerializeField] private bool isGrounded = true;
    RaycastHit2D[] raycastHit = new RaycastHit2D[5];
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
       IsGrounded = capsuleCollider.Cast(Vector2.down, contactFilter, raycastHit, groundDistance) > 0;
    }

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
}
