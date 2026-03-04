using UnityEngine;
using System.Collections.Generic;

namespace FirstRoguelike.Bloodlines
{
    [CreateAssetMenu(fileName = "NewSynergyTier", menuName = "FirstRoguelike/Synergy Tier")]
    public class SynergyTierSO : ScriptableObject
    {
        [Header("Tier Settings")]
        public int threshold;           // e.g. 2 for 2/2, 4 for 4/4
        public string tierName;         // e.g. "Bronze", "Gold", "Legendary"
        public Color tierColor;         // for UI highlighting later

        [Header("Rewards")]
        public List<StatModifierSO> modifiers;

        [Header("Description")]
        [TextArea] public string description; // e.g. "Enemies burn on hit"
    }
}