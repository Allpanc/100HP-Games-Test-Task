using TestTask100HPGames.Base;
using TestTask100HPGames.Enemy.Spawn;
using Zenject;

namespace TestTask100HPGames.Utils
{
    public class LocationInstaller : MonoInstaller
    {
        public Tower Tower;
        public EnemySpawner EnemySpawner;
        public EnemyTracker EnemyTracker;
        public ObjectPool ObjectPool;
        public CountdownDisplay CountdownDisplay;

        public override void InstallBindings()
        {
            BindTower();
            BindEnemySpawner();
            BindEnemyTracker();
            BindObjectPool();
            BindCountdownDisplay();
        }

        private void BindTower()
        {
            Container
                .Bind<Tower>()
                .FromInstance(Tower)
                .AsSingle();
        }

        private void BindEnemySpawner()
        {
            Container
                .Bind<EnemySpawner>()
                .FromInstance(EnemySpawner)
                .AsSingle();
        }

        private void BindEnemyTracker()
        {
            Container
                .Bind<EnemyTracker>()
                .FromInstance(EnemyTracker)
                .AsSingle();
        }

        private void BindObjectPool()
        {
            Container
                .Bind<ObjectPool>()
                .FromInstance(ObjectPool)
                .AsSingle();
        }

        private void BindCountdownDisplay()
        {
            Container
                .Bind<CountdownDisplay>()
                .FromInstance(CountdownDisplay)
                .AsSingle();
        }
    }
}
