using TestTask100HPGames.Statistics;
using UnityEngine;

namespace TestTask100HPGames
{
    [CreateAssetMenu(fileName = "UpgradeInfo", menuName = "Gameplay/New UpgradeInfo")]
    public class UpgradeInfo : ScriptableObject
    {
        [SerializeField]
        private Stat _stat;

        [SerializeField]
        private float _amount;

        [SerializeField]
        private int _level;

        [SerializeField]
        private int _cost;

        public Stat Stat => _stat;
        public float Amount => _amount;
        public int Level => _level;
        public int Cost => _cost;

        public void Apply(Stats stats)
        {
            float currentStatValue = stats.GetStat(Stat);
            float newStatValue = currentStatValue + Amount;
            stats.SetStat(Stat, newStatValue);
        }
    }
}
