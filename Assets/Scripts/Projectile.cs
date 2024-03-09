using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 travelSpeed = new Vector2(3f, 0);
    public Vector2 knockback = new Vector2(0,0);
    public int damage = 10;
    Rigidbody2D Rigidbody;
    // Start is called before the first frame update
    void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.velocity = new Vector2(travelSpeed.x * transform.localScale.x, travelSpeed.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health damageable = collision.GetComponent<Health>();
        if(damageable != null)
        {
            Vector2 flipKnockback = transform.localScale.x > 0 ? knockback : new Vector2(-knockback.x, knockback.y);
            bool gotHit = damageable.Hit(damage, flipKnockback);
            if(gotHit)
            {
                Destroy(gameObject);
                 Debug.Log(collision.name + " hit for " + damage + " damage");
            }
           
        }
    }
}
