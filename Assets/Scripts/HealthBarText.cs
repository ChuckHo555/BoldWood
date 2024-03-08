using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBarText : MonoBehaviour
{
    public Vector3 moveSpeed = new Vector3(0, 60, 0);
    public RectTransform rectTransform;
    public float fadeTime = 1f;
    TextMeshProUGUI textMeshPro;
    private float timeElapsed = 0f;
    private Color color;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        color = textMeshPro.color;
    }

    void Update()
    {
        rectTransform.position += moveSpeed * Time.deltaTime;
        timeElapsed += Time.deltaTime;

        float alphaColor = color.a * (1 - (timeElapsed / fadeTime));

        if (timeElapsed < fadeTime)
        {
            textMeshPro.color = new Color(color.r, color.g, color.b, alphaColor);
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
