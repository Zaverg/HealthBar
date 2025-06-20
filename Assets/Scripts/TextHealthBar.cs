using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealthBar : HealthBar
{
    private TextMeshProUGUI _textHeath;

    private void Awake()
    {
        _textHeath = GetComponent<TextMeshProUGUI>();
    }

    protected override void UpdateHealthPointBar(float currentHP, float maxHP)
    {
        _textHeath.text = $"{currentHP}/{maxHP}";
    }
}
