using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeballScript : MonoBehaviour
{
    public DetectionRange attackRangeZone;
    public bool targetDetected = false;
    Animator animator;
    Rigidbody2D rigidbody;
    public List<Transform> wayPoints = new List<Transform>();
    public float flySpeed = 3f;
    Health health;
    int wayPointNumber = 0;
    Transform waypointTracking;
    public float wayPointDistanceReached = 0.1f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
    }

    void Start()
    {
        if (wayPoints.Count > 0)
            waypointTracking = wayPoints[wayPointNumber];
        else
            Debug.LogWarning("No waypoints assigned to FlyingEyeballScript on " + gameObject.name);
    }

    void Update()
    {
        TargetDetected = attackRangeZone.detectedColliders.Count > 0;
    }

    void FixedUpdate()
    {
        if (health.IsAlive)
        {
            if (YesMove)
            {
                Fly();
            }
            else
            {
            rigidbody.velocity = Vector3.zero;
            }
        }
        else
        {
            rigidbody.gravityScale = 2f;
            rigidbody.velocity = new Vector2 (0, rigidbody.velocity.y);
        }
       
    }
    public bool YesMove
    {
        get
        {
            return animator.GetBool("yesMove");
        }
    }

    public bool TargetDetected
    {
        get { return targetDetected; }
        set
        {
            targetDetected = value;
            animator.SetBool("targetDetected", value);
        }
    }

    void Fly()
    {
        if (waypointTracking != null)
        {
            Vector2 moveNextWaypoint = (waypointTracking.position - transform.position).normalized;
            float distance = Vector2.Distance(waypointTracking.position, transform.position);
            rigidbody.velocity = moveNextWaypoint * flySpeed;
            FlipDirection();

            if (distance <= wayPointDistanceReached)
            {
                wayPointNumber = (wayPointNumber + 1) % wayPoints.Count; // Move to the next waypoint in a loop
                waypointTracking = wayPoints[wayPointNumber];
            }
        }
        else
        {
            Debug.LogWarning("No waypoint assigned to waypointTracking on " + gameObject.name);
        }
    }
    public void FlipDirection()
    {
        Vector3 currentScale = transform.localScale;
        if(transform.localScale.x > 0)
        {
            if(rigidbody.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1 * currentScale.x, currentScale.y, currentScale.z);
            }
        }
        else
        {
            if(rigidbody.velocity.x > 0)
            {
                transform.localScale = new Vector3(-1 * currentScale.x, currentScale.y, currentScale.z);
            }
        }
    }
}