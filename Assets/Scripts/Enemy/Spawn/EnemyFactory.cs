using System;
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

        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Load()
        {
            _skeletonPrefab = Resources.Load<Skeleton>("Skeleton");
            _orcPrefab = Resources.Load<Orc>("Orc");
            _knightPrefab = Resources.Load<Knight>("Knight");
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