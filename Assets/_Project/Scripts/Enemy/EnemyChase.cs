using UnityEngine;
using FirstRoguelike.Stats;
using FirstRoguelike.Core;

namespace FirstRoguelike.Enemy
{
    public class EnemyChase : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private float baseSpeed = 2f;

        private StatSheet _statSheet;
        private Rigidbody2D _rb;
        private Transform _playerTransform;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();

            // Hook up death
            GetComponent<HealthComponent>().OnDeath += () => Destroy(gameObject);

            var baseStats = new System.Collections.Generic.Dictionary<StatType, float>
    {
        { StatType.MoveSpeed, baseSpeed }
    };
            _statSheet = new StatSheet(baseStats);
        }

        private void Start()
        {
            // Find the player by tag
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                _playerTransform = player.transform;
            else
                Debug.LogWarning("EnemyChase: No GameObject with tag 'Player' found!");
        }

        private void FixedUpdate()
        {
            if (_playerTransform == null) return;

            float speed = _statSheet.GetStat(StatType.MoveSpeed);
            Vector2 direction = (_playerTransform.position - transform.position).normalized;
            _rb.linearVelocity = direction * speed;
        }
    }
}