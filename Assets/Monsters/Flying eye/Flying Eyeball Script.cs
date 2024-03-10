using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeballScript : MonoBehaviour
{
    public DetectionRange attackRangeZone;
    public bool targetDetected = false;
    Animator animator;
    Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
       animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        TargetDetected = attackRangeZone.detectedColliders.Count > 0;
    }

    public bool TargetDetected
    {
        get
        {
            return targetDetected;
        }
        set
        {
            targetDetected = value;
            animator.SetBool("targetDetected", value);
        }
    }
}
