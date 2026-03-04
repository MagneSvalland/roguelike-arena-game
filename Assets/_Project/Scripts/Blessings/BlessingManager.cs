using UnityEngine;
using System.Collections.Generic;
using FirstRoguelike.Bloodlines;

namespace FirstRoguelike.Blessings
{
    public class BlessingManager : MonoBehaviour
    {
        [Header("All Available Blessings")]
        [SerializeField] private List<BlessingSO> allBlessings;

        [Header("All Available Bloodlines")]
        [SerializeField] private List<BloodlineSO> allBloodlines;

        public List<(BlessingSO blessing, BloodlineSO bloodline)> GetRandomOffer(int count = 3)
        {
            var offer = new List<(BlessingSO, BloodlineSO)>();
            var pool = new List<BlessingSO>(allBlessings);

            for (int i = 0; i < count && pool.Count > 0; i++)
            {
                int blessingIndex = Random.Range(0, pool.Count);
                int bloodlineIndex = Random.Range(0, allBloodlines.Count);

                offer.Add((pool[blessingIndex], allBloodlines[bloodlineIndex]));
                pool.RemoveAt(blessingIndex);
            }

            return offer;
        }
    }
}