using UnityEngine;
using FirstRoguelike.Core;
using FirstRoguelike.Stats;

namespace FirstRoguelike.Weapons
{
    public class MageAttackStrategy : IAttackStrategy
    {
        private readonly GameObject _projectilePrefab;
        private readonly StatSheet _statSheet;

        public MageAttackStrategy(GameObject projectilePrefab, StatSheet statSheet)
        {
            _projectilePrefab = projectilePrefab;
            _statSheet = statSheet;
        }

        public void Attack(Transform origin, Transform target)
        {
            if (target == null || _projectilePrefab == null) return;

            Vector2 direction = (target.position - origin.position).normalized;
            float damage = _statSheet.GetStat(StatType.Damage);
            float projSpeed = 8f;

            GameObject proj = GameObject.Instantiate(
                _projectilePrefab,
                origin.position,
                Quaternion.identity
            );

            proj.GetComponent<ProjectileBehaviour>()
                .Initialize(direction, projSpeed, damage);
        }

        public float GetAttackCooldown()
        {
            // Higher AttackSpeed stat = shorter cooldown
            float attackSpeed = _statSheet.GetStat(StatType.AttackSpeed);
            return 1f / attackSpeed;
        }
    }
}