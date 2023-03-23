using System;

namespace TestTask100HPGames.Statistics.Upgradings
{
    public class Upgrade : IUpgrade
    {
        private Stats _stats;
        public Stat Stat { get; private set; }
        public float Amount { get; private set; }
        public int Level { get; private set; }
        public int Cost { get; private set; }

        public Upgrade(Stats stats, Stat stat, float amount, int level, int cost)
        {
            _stats = stats;
            Stat = stat;
            Amount = amount;
            Level = level;
            Cost = cost;
        }

        public void Apply()
        {
            float currentStatValue = _stats.GetStat(Stat);
            float newStatValue = currentStatValue + Amount;
            _stats.SetStat(Stat, newStatValue);
        }
    }
}
