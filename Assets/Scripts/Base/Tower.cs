using System;
using System.Collections.Generic;
using TestTask100HPGames.Base.Shooting;
using TestTask100HPGames.Statistics;
using TestTask100HPGames.Statistics.Upgradings;
using UnityEngine;

namespace TestTask100HPGames.Base
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] 
        private ShootingSystem ShootingSystem;

        public Stats Stats;

        [SerializeField] 
        private List<UpgradeInfo> upgradeInfos;

        public UpgradeInfoProvider UpgradeInfoProvider { get; private set; }

        public event Action OnReached;

        private void Start()
        {
            InitializeUpgrades();
        }

        public void StartAttack()
        {
            ShootingSystem.StartShooting();
        }

        public void FinishAttack()
        {
            ShootingSystem.StopShooting();
        }

        private void OnTriggerEnter(Collider other)
        {
            OnReached.Invoke();
        }

        private void InitializeUpgrades()
        {
            UpgradeInfoProvider = new UpgradeInfoProvider(upgradeInfos, Stats);
        }
    }
}
