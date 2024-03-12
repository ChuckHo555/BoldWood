using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    Health hasHealth;
    public Slider healthBar;
    // Start is called before the first frame update
    void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        hasHealth = player.GetComponent<Health>();
       
    }
    private void Start()
    {
        healthBar.value = sliderPercentage(hasHealth.CurrentHealth, hasHealth.MaxHealth);
    }

    public float sliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEnable()
    {
        hasHealth.heatlhChanged.AddListener(HealthChanged);
    }
    public void OnDisable()
    {
        hasHealth.heatlhChanged.RemoveListener(HealthChanged);
    }
    public void HealthChanged(int newHealth, int maxHealth)
    {
        healthBar.value = sliderPercentage(newHealth, maxHealth);
    }
}
