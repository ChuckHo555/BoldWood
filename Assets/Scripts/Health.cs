using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;
    private bool isAlive = true;
    private bool invincible = false;
    Animator animator;
    private float timeFromHit = 0;
    public float invincibleDuration = 0.8f;

    private void FixedUpdate()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(invincible)
        {
            if(timeFromHit > invincibleDuration)
            {
                invincible = false;
                timeFromHit = 0;
            }
            timeFromHit += Time.deltaTime;
        }
        
    }


    public int MaxHealth { get { return maxHealth; } set { maxHealth = value; } }
    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;

            if (currentHealth <= 0)
            {
                IsAlive = false;
            }

        }
    }

    public bool IsAlive { get{ return isAlive; }
        private set { isAlive = value;
            animator.SetBool("isAlive", value);
          
        }
    }
    public void Hit(int damage)
    {
        if (IsAlive)
        {
            CurrentHealth -= damage;
            invincible = true;
        }
    }
}
