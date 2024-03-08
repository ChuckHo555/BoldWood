using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    public int healAmount = 15;
    public Vector3 spinSpeed = new Vector3 (0, 180, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += spinSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health hasHealth = collision.GetComponent<Health>();
        if (hasHealth)
        {
            bool wasHealed = hasHealth.Heal(healAmount);
            if (wasHealed)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
