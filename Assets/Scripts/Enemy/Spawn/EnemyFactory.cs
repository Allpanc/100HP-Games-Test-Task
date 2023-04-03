using System;
using TestTask100HPGames.Utils.Services;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace TestTask100HPGames.Enemy.Spawn
{
    public class EnemyFactory
    {
        private Skeleton _skeletonPrefab;
        private Orc _orcPrefab;
        private Knight _knightPrefab;
        private DiContainer _diContainer;
        private AssetsProvider _assets;

        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _assets = new AssetsProvider();

            Load();
        }

        private void Load()
        {
            _skeletonPrefab = _assets.Skeleton();
            _orcPrefab = _assets.Orc();
            _knightPrefab = _assets.Knight();
        }

        public void Spawn(EnemyType enemyType, Vector3 position, Quaternion rotation)
        {
            switch (enemyType)
            {
                case EnemyType.Skeleton:
                    _diContainer.InstantiatePrefab(_skeletonPrefab, position, rotation, null);
                    break;
                case EnemyType.Orc:
                    _diContainer.InstantiatePrefab(_orcPrefab, position, rotation, null);
                    break;
                case EnemyType.Knight:
                    _diContainer.InstantiatePrefab(_knightPrefab, position, rotation, null);
                    break;
            }
        }

        public void SpawnRandomEnemy(Vector3 position, Quaternion rotation)
        {
            Array values = Enum.GetValues(typeof(EnemyType));
            Random random = new Random();
            EnemyType randomEnemyType = (EnemyType)values.GetValue(random.Next(values.Length));

            Spawn(randomEnemyType, position, rotation);
        }
    }
}