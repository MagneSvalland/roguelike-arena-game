using UnityEngine;
using UnityEngine.UI;
using FirstRoguelike.Core;

namespace FirstRoguelike.UI
{
    public class HealthBarUI : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Image fillImage;
        [SerializeField] private HealthComponent healthComponent;

        private void OnEnable()
        {
            healthComponent.OnHealthChanged += UpdateBar;
        }

        private void OnDisable()
        {
            healthComponent.OnHealthChanged -= UpdateBar;
        }

        private void UpdateBar(float current, float max)
        {
            fillImage.fillAmount = current / max;
        }

        private void Start()
        {
            UpdateBar(healthComponent.CurrentHealth, healthComponent.MaxHealth);
        }
    }
}