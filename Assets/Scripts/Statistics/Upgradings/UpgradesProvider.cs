using System.Collections.Generic;

namespace TestTask100HPGames.Statistics.Upgradings
{
    public class UpgradesProvider
    {
        private Stats _stats;

        public UpgradesProvider(Stats stats)
        {
            _stats = stats;
        }

        public List<Upgrade> GetTowerUpgradesList()
        {
            List<Upgrade> upgrades = new List<Upgrade>();

            Upgrade damage1 = new Upgrade(_stats, Stat.Damage, 0.5f, 1, 5);
            Upgrade damage2 = new Upgrade(_stats, Stat.Damage, 1.5f, 2, 10);

            Upgrade shootingSpeed1 = new Upgrade(_stats, Stat.ShootingSpeed, 0.2f, 1, 5);
            Upgrade shootingSpeed2 = new Upgrade(_stats, Stat.ShootingSpeed, 0.2f, 2, 10);
            Upgrade shootingSpeed3 = new Upgrade(_stats, Stat.ShootingSpeed, 0.2f, 3, 15);

            Upgrade reach1 = new Upgrade(_stats, Stat.Reach, 5f, 1, 5);
            Upgrade reach2 = new Upgrade(_stats, Stat.Reach, 5f, 2, 5);
            Upgrade reach3 = new Upgrade(_stats, Stat.Reach, 5f, 3, 5);

            upgrades.Add(damage1);
            upgrades.Add(damage2);

            upgrades.Add(shootingSpeed1);
            upgrades.Add(shootingSpeed2);
            upgrades.Add(shootingSpeed3);

            upgrades.Add(reach1);
            upgrades.Add(reach2);
            upgrades.Add(reach3);

            return upgrades;
        }
    }
}
