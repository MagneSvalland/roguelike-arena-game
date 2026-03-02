using UnityEngine;
using FirstRoguelike.Core;
using FirstRoguelike.Stats;
using System.Collections.Generic;

namespace FirstRoguelike.Weapons
{
    public class WeaponController : MonoBehaviour
    {
        [Header("Weapon Settings")]
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float baseAttackSpeed = 1f;
        [SerializeField] private float baseDamage = 10f;

        private IAttackStrategy _attackStrategy;
        private StatSheet _statSheet;
        private float _attackTimer;

        private void Awake()
        {
            var baseStats = new Dictionary<StatType, float>
            {
                { StatType.Damage, baseDamage },
                { StatType.AttackSpeed, baseAttackSpeed }
            };
            _statSheet = new StatSheet(baseStats);
            _attackStrategy = new MageAttackStrategy(projectilePrefab, _statSheet);
        }

        private void Update()
        {
            _attackTimer += Time.deltaTime;
            float cooldown = _attackStrategy.GetAttackCooldown();

            if (_attackTimer >= cooldown)
            {
                _attackTimer = 0f;
                Transform nearest = FindNearestEnemy();
                _attackStrategy.Attack(transform, nearest);
            }
        }

        private Transform FindNearestEnemy()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Transform nearest = null;
            float minDist = Mathf.Infinity;

            foreach (GameObject enemy in enemies)
            {
                float dist = Vector2.Distance(transform.position, enemy.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    nearest = enemy.transform;
                }
            }
            return nearest;
        }
    }
}