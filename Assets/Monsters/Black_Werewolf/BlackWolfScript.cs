using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWolfScript : MonoBehaviour
{
    public float walkSpeed = 3f;
    Rigidbody2D rigibody;
    public enum WalkDirection { Left, Right };
    private WalkDirection walkdirection;
    private Vector2 walkVector;
    

    public WalkDirection _WalkDirection
    {
        get { return walkdirection; }
        set
        {
            if (walkdirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == WalkDirection.Left)
                {
                    walkVector = Vector2.left; 
                }
                else if(value == WalkDirection.Right)
                {
                    walkVector = Vector2.right; 
                }
            }
            walkdirection = value;
        }
    }
    private void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        rigibody.velocity = new Vector2(walkSpeed * Vector2.right.x, rigibody.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
