using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageble, IHealebel
{
    public event Action<float, float> HealthChanged;

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth - damage >= 0)
        {
            _currentHealth -= damage;
        }
        else
        {
            _currentHealth = 0;
        }

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
        HandleDeath();
    }

    public void Heal(float heal)
    {
        if(_currentHealth + heal <= _maxHealth)
        {
            _currentHealth += heal;
        }
        else
        {
            _currentHealth = _maxHealth;
        }

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    private void HandleDeath()
    {
        if (_currentHealth <= 0)
            gameObject.SetActive(false);
    }
}
