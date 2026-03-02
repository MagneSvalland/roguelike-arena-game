using UnityEngine;
using FirstRoguelike.Core;

namespace FirstRoguelike.Weapons
{
    public class ProjectileBehaviour : MonoBehaviour
    {
        private Vector2 _direction;
        private float _speed;
        private float _damage;
        private float _lifetime = 3f;

        public void Initialize(Vector2 direction, float speed, float damage)
        {
            _direction = direction;
            _speed = speed;
            _damage = damage;
            Destroy(gameObject, _lifetime);
        }

        private void Update()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                HealthComponent health = other.GetComponent<HealthComponent>();
                if (health != null)
                    health.TakeDamage(_damage);

                Destroy(gameObject);
            }
        }
    }
}