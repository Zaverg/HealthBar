using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderHealthBar : HealthBar
{
    protected Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    protected override void UpdateHealthPointBar(float currentHP, float maxHP)
    {
        float value = ConversionToSliderValue(currentHP, maxHP);

        _slider.value = value;
    }

    protected float ConversionToSliderValue(float amount, float maxAmount)
    {
        float precentFactor = 100;

        return amount * maxAmount / precentFactor / precentFactor;
    }
}
