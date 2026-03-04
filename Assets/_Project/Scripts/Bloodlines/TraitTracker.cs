using UnityEngine;
using System.Collections.Generic;
using FirstRoguelike.Bloodlines;
using FirstRoguelike.Core;
using FirstRoguelike.Blessings;

namespace FirstRoguelike.Bloodlines
{
    public class TraitTracker : MonoBehaviour
    {
        private Dictionary<BloodlineSO, int> _bloodlineCounts = new();

        private void OnEnable()
        {
            GameEvents.OnUpgradePicked += HandleUpgradePicked;
        }

        private void OnDisable()
        {
            GameEvents.OnUpgradePicked -= HandleUpgradePicked;
        }

        private void HandleUpgradePicked(string blessingName)
        {
            // SynergyEvaluator will handle this, just fire stats changed
            GameEvents.StatsChanged();
        }

        public void AddBloodline(BloodlineSO bloodline)
        {
            if (!_bloodlineCounts.ContainsKey(bloodline))
                _bloodlineCounts[bloodline] = 0;

            _bloodlineCounts[bloodline]++;
            Debug.Log($"{bloodline.bloodlineName}: {_bloodlineCounts[bloodline]}");
            GameEvents.StatsChanged();
        }

        public int GetCount(BloodlineSO bloodline)
        {
            return _bloodlineCounts.TryGetValue(bloodline, out int count) ? count : 0;
        }

        public Dictionary<BloodlineSO, int> GetAllCounts() => _bloodlineCounts;
    }
}