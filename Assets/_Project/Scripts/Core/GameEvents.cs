using System;

namespace FirstRoguelike.Core
{
    public static class GameEvents
    {
        public static event Action<string> OnUpgradePicked;
        public static event Action OnStatsChanged;

        public static void UpgradePicked(string upgradeId)
        {
            OnUpgradePicked?.Invoke(upgradeId);
        }

        public static void StatsChanged()
        {
            OnStatsChanged?.Invoke();
        }
    }
}