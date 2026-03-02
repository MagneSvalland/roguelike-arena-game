using UnityEngine;
using FirstRoguelike.Stats;

namespace FirstRoguelike.Bloodlines
{
    [CreateAssetMenu(fileName = "NewStatModifier", menuName = "FirstRoguelike/Stat Modifier")]
    public class StatModifierSO : ScriptableObject
    {
        public StatType statType;
        public ModifierType modifierType;
        public float value;
    }
}