using UnityEngine;
using System.Collections.Generic;
using FirstRoguelike.Bloodlines;
using FirstRoguelike.Core;

namespace FirstRoguelike.Blessings
{
    public class PlayerInventory : MonoBehaviour
    {
        private List<(BlessingSO blessing, BloodlineSO bloodline)> _ownedBlessings = new();

        public IReadOnlyList<(BlessingSO blessing, BloodlineSO bloodline)> OwnedBlessings
            => _ownedBlessings;

        public void AddBlessing(BlessingSO blessing, BloodlineSO bloodline)
        {
            _ownedBlessings.Add((blessing, bloodline));
            GameEvents.UpgradePicked(blessing.blessingName);
        }
    }
}