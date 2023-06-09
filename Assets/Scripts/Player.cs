using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly float _healValue = 10f;
    private readonly float _maxHealth = 100f;
    private float _currentHealth;
    
    public Action<float, float> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (_currentHealth == 0)
            return;
        
        _currentHealth -= damage;
        
        if (_currentHealth < 0)
            _currentHealth = 0;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void Heal()
    {
        if (_currentHealth == _maxHealth)
            return;
        
        _currentHealth += _healValue;
        
        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}
