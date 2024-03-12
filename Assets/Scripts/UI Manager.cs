using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject healText;
    public GameObject damageText;
    public Canvas gameCanvas;


    private void Awake()
    {
        gameCanvas = FindObjectOfType<Canvas>();
        
    }

    private void OnEnable()
    {
        CharacterEvents.characterDamaged += TakingDamage;
        CharacterEvents.characterHealed +=Healed;
    }

    private void OnDisable()
    {
        CharacterEvents.characterDamaged -= TakingDamage;
        CharacterEvents.characterHealed -= Healed;
    }

    public void TakingDamage(GameObject Character, int damage)
    {
        Vector3 textPosition = Camera.main.WorldToScreenPoint(Character.transform.position);

        TMP_Text tMP_Text = Instantiate(damageText, textPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();

        tMP_Text.text = damage.ToString();
    }

    public void Healed(GameObject Character, int healingAmount) 
    {
        Vector3 textPosition = Camera.main.WorldToScreenPoint(Character.transform.position);

        TMP_Text tMP_Text = Instantiate(healText, textPosition, Quaternion.identity, gameCanvas.transform).GetComponent<TMP_Text>();

        tMP_Text.text = healingAmount.ToString();
    }
}
