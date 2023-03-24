using System.Threading.Tasks;
using TestTask100HPGames.Statistics;
using UnityEngine;
using Zenject;

namespace TestTask100HPGames.Base
{
    public class AoE : MonoBehaviour
    {
        private Tower _tower;

        [Inject]
        private void Construct(Tower tower)
        {
            _tower = tower;
        }

        private void Start()
        {
            SubscribeToReachUpdates();
            UpdateReach(Stat.Reach);
        }

        public void UpdateReach(Stat stat)
        {
            if (stat != Stat.Reach)
                return;

            float size = _tower.Stats.GetStat(Stat.Reach) * 2;
            transform.localScale = new Vector3(size, transform.localScale.y, size);
        }

        private async void SubscribeToReachUpdates()
        {
            await Task.Yield();
            _tower.UpgradeInfoProvider.OnApplied += UpdateReach;
        }
    }
}
