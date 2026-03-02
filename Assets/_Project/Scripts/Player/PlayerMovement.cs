using UnityEngine;
using UnityEngine.InputSystem;
using FirstRoguelike.Stats;

namespace FirstRoguelike.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Stats")]
        [SerializeField] private float baseSpeed = 5f;

        private StatSheet _statSheet;
        private Vector2 _moveInput;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();

            // Initialize stat sheet with base speed
            var baseStats = new System.Collections.Generic.Dictionary<StatType, float>
            {
                { StatType.MoveSpeed, baseSpeed }
            };
            _statSheet = new StatSheet(baseStats);
        }

        // Called automatically by the Input System
        public void OnMove(InputValue value)
        {
            _moveInput = value.Get<Vector2>();
        }

        private void FixedUpdate()
        {
            float speed = _statSheet.GetStat(StatType.MoveSpeed);
            _rb.linearVelocity = _moveInput * speed;
        }
    }
}