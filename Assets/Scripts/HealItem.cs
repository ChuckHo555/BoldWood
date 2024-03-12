using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour
{
    public int healAmount = 15;
    public Vector3 spinSpeed = new Vector3 (0, 180, 0);
    public AudioSource healSound;

    // Start is called before the first frame update
    void Awake()
    {
        healSound = GetComponent<AudioSource>();
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
                if (healSound)
                {
                    AudioSource.PlayClipAtPoint(healSound.clip, gameObject.transform.position, healSound.volume);
                     Destroy(gameObject);
                }
               
            }
            
        }
    }
}
