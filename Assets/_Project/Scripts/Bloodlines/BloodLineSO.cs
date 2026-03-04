using UnityEngine;
using System.Collections.Generic;

namespace FirstRoguelike.Bloodlines
{
    [CreateAssetMenu(fileName = "NewBloodline", menuName = "FirstRoguelike/Bloodline")]
    public class BloodlineSO : ScriptableObject
    {
        [Header("Identity")]
        public string bloodlineName;
        public Sprite icon;
        public Color color;

        [Header("Synergy Tiers")]
        public List<SynergyTierSO> tiers; // ordered by threshold e.g. 2, 4, 6
    }
}