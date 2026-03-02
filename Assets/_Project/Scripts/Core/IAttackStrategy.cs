using UnityEngine;

namespace FirstRoguelike.Core
{
    public interface IAttackStrategy
    {
        void Attack(Transform origin, Transform target);
        float GetAttackCooldown();
    }
}