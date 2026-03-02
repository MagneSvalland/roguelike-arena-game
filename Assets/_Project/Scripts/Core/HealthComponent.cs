using UnityEngine;
using System;

namespace FirstRoguelike.Core
{
    public class HealthComponent : MonoBehaviour
    {
        [Header("Health Settings")]
        [SerializeField] private float maxHealth = 100f;

        private float _currentHealth;

        public float CurrentHealth => _currentHealth;
        public float MaxHealth => maxHealth;
        public bool IsDead => _currentHealth <= 0f;

        public event Action<float, float> OnHealthChanged; // current, max
        public event Action OnDeath;

        private void Awake()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(float amount)
        {
            if (IsDead) return;

            _currentHealth = Mathf.Max(0f, _currentHealth - amount);
            OnHealthChanged?.Invoke(_currentHealth, maxHealth);

            if (IsDead)
                OnDeath?.Invoke();
        }

        public void Heal(float amount)
        {
            if (IsDead) return;

            _currentHealth = Mathf.Min(maxHealth, _currentHealth + amount);
            OnHealthChanged?.Invoke(_currentHealth, maxHealth);
        }
    }
}