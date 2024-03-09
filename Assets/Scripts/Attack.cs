using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Collider2D attackCollider;
    public int hitDamage = 10;
    public Vector2 knockback = Vector2.zero;

    private void Awake()
    {
        attackCollider = GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       Health damageable = other.GetComponent<Health>();
        
        if (damageable != null)
        {
            Vector2 flipKnockback = transform.parent.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            damageable.Hit(hitDamage, flipKnockback);
            Debug.Log(other.name + " hit for " + hitDamage + " damage");
        }
    }
}
