using UnityEngine;
using FirstRoguelike.Core;

namespace FirstRoguelike.Enemy
{
    public class EnemyContact : MonoBehaviour
    {
        [SerializeField] private float damagePerSecond = 10f;

        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                HealthComponent health = other.gameObject.GetComponent<HealthComponent>();
                if (health != null)
                    health.TakeDamage(damagePerSecond * Time.fixedDeltaTime);
            }
        }
    }
}