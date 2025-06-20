using System.Collections;
using UnityEngine;

public class SmoothSliderHealthBar : SliderHealthBar
{   
    [SerializeField, Range(0.01f, 1f)] private float _speedChange;

    private Coroutine _coroutine;

    protected override void UpdateHealthPointBar(float currentHP, float maxHP)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        
        float currentHPPrecetn = ConversionToSliderValue(currentHP, maxHP);

        _coroutine = StartCoroutine(StartCangingHP(currentHPPrecetn));
    }

    private IEnumerator StartCangingHP(float target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _speedChange * Time.deltaTime);

            yield return null;
        }
    }
}
