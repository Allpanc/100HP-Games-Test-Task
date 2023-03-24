using System;
using System.Collections.Generic;
using TestTask100HPGames.Finances;

namespace TestTask100HPGames.Statistics.Upgradings
{
    public class UpgradeInfoProvider
    {
        private Dictionary<Stat, int> _statUpgradeLevelMap = new Dictionary<Stat, int>();
        private List<UpgradeInfo> _upgrades;
        private Stats _stats;

        public event Action<Stat> OnApplied;

        public UpgradeInfoProvider(List<UpgradeInfo> upgrades, Stats stats)
        {
            _stats = stats;
            _upgrades = upgrades;
            foreach (StatInfo statInfo in stats.stats)
            {
                _statUpgradeLevelMap.Add(statInfo.Stat, 0);
            }
        }

        public void Apply(Stat stat)
        {
            int currentLevel = _statUpgradeLevelMap[stat];

            UpgradeInfo upgrade = _upgrades.Find(x => x.Stat == stat && x.Level == currentLevel + 1);
            Balance.Instance.Remove(upgrade.Cost);

            _statUpgradeLevelMap[stat] = upgrade.Level;
            upgrade.Apply(_stats);
            OnApplied?.Invoke(stat);
        }

        public bool IsAvaliable(Stat stat)
        {
            int currentLevel = _statUpgradeLevelMap[stat];

            UpgradeInfo upgrade = _upgrades.Find(x => x.Stat == stat && x.Level == currentLevel + 1);

            if (upgrade == null)
                return false;

            if (upgrade.Cost > Balance.Instance.Coins)
                return false;

            return true;
        }

        public UpgradeInfo Initial(Stat stat)
        {
            UpgradeInfo upgrade = _upgrades.Find(x => x.Stat == stat && x.Level == 1);
            return upgrade;
        }

        public UpgradeInfo Current(Stat stat)
        {
            int currentLevel = _statUpgradeLevelMap[stat];

            UpgradeInfo upgrade = _upgrades.Find(x => x.Stat == stat && x.Level == currentLevel);
            return upgrade;
        }

        public UpgradeInfo Next(Stat stat)
        {
            int currentLevel = _statUpgradeLevelMap[stat];

            UpgradeInfo upgrade = _upgrades.Find(x => x.Stat == stat && x.Level == currentLevel + 1);
            return upgrade;
        }
    }
}
