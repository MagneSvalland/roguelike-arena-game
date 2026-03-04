using UnityEngine;
using System.Collections.Generic;
using FirstRoguelike.Bloodlines;

namespace FirstRoguelike.Blessings
{
    [CreateAssetMenu(fileName = "NewBlessing", menuName = "FirstRoguelike/Blessing")]
    public class BlessingSO : ScriptableObject
    {
        [Header("Identity")]
        public string blessingName;
        public Sprite icon;
        [TextArea] public string description;

        [Header("Stat Effects")]
        public List<StatModifierSO> modifiers;
    }
}