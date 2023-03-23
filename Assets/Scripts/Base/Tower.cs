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

        public Upgrades Upgrades { get; private set; }

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
            UpgradesProvider upgradesProvider = new UpgradesProvider(Stats);
            List<Upgrade> upgrades = upgradesProvider.GetTowerUpgradesList();
            Upgrades = new Upgrades(upgrades, Stats);
        }
    }
}
