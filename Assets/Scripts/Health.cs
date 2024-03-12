using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;
    private bool isAlive = true;
    private bool invincible = false;
    Animator animator;
    private float timeFromHit = 0;
    public float invincibleDuration = 0.5f;
    public UnityEvent<int, Vector2> successHit;
    public UnityEvent<int, int> heatlhChanged;

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
            heatlhChanged?.Invoke(CurrentHealth, MaxHealth);

            if (currentHealth <= 0)
            {
                IsAlive = false;
            }

        }
    }

    public bool IsAlive {
        get{ return isAlive; }
        private set { 
            isAlive = value;
            animator.SetBool("isAlive", value);
          
        }
    }
    public bool Hit(int damage, Vector2 knockback)
    {
        if (IsAlive && !invincible)
        {
            CurrentHealth -= damage;
            invincible = true;
            WasHit = true;
            successHit?.Invoke(damage, knockback);
            CharacterEvents.characterDamaged(gameObject, damage);
            return true;
        }
        return false;
    }
    public bool WasHit
    {
        get => animator.GetBool("wasHit"); 
        set
        {
            animator.SetBool("wasHit", value);
        }

    }
    public bool Heal(int healAmount)
    {
            if(IsAlive && CurrentHealth < maxHealth)
            {
            int maxHeal = Mathf.Max(maxHealth - CurrentHealth, 0);
            int cappedHeal = Mathf.Min(maxHeal, healAmount);
            CurrentHealth += cappedHeal;
            CharacterEvents.characterHealed(gameObject, cappedHeal);
            return true;
            }

            return false;        
    }
}
