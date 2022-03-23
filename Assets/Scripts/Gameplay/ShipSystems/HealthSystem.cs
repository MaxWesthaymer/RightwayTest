using System;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class HealthSystem : MonoBehaviour
    {
        public event Action<float> HealthChanged;
        public event Action OnDeath;
        [SerializeField] private float _maxHealth = 1000;

        private float _currentHealth;

        public void Init()
        {
            _currentHealth = _maxHealth;
            HealthChanged?.Invoke(_currentHealth);
        }

        public void TakeDamage(float damage)
        {
            if (_currentHealth - damage <= 0)
            {
                _currentHealth = 0;
                HealthChanged?.Invoke(_currentHealth);
                OnDeath?.Invoke();
                return;
            }

            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth);
        }

        public void GiveHealth(float value)
        {
            if (_currentHealth + value >= _maxHealth)
            {
                _currentHealth = _maxHealth;
                HealthChanged?.Invoke(_currentHealth);
                return;
            }
            _currentHealth += value;
            HealthChanged?.Invoke(_currentHealth);
        }
    }
}