using System.Collections;
using TestTask100HPGames.Base;
using TestTask100HPGames.Statistics;
using TestTask100HPGames.Utils;
using UnityEngine;
using Zenject;

namespace TestTask100HPGames.Enemy.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private float _spawnRadius;

        [SerializeField]
        private float _timeBetweenSpawns = 3f;

        private EnemyFactory _factory;
        private Coroutine _spawnRoutine;
        private Tower _tower;

        [Inject]
        private void Construct(Tower tower, DiContainer diContainer)
        {
            _factory = new EnemyFactory(diContainer);
            
            _tower = tower;
            SpawnTransformsHelper.CenterPos = _tower.transform.position;
        }

        private void Start()
        {
            _factory.Load();
        }

        public void Activate()
        {
            _spawnRoutine = StartCoroutine(SpawnEnemies());
        }

        public void Deactivate()
        {
            StopCoroutine(_spawnRoutine);
        }

        private IEnumerator SpawnEnemies()
        {
            while (true)
            {
                yield return new WaitForSeconds(_timeBetweenSpawns);
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            float reach = _tower.Stats.GetStat(Stat.Reach);
            Vector3 spawnPosition = SpawnTransformsHelper.GetSpawnPosition(reach * 1.5f);
            Quaternion spawnRotation = SpawnTransformsHelper.GetSpawnRotation(spawnPosition);

            _factory.SpawnRandomEnemy(spawnPosition, spawnRotation);
        }

        private void OnDestroy()
        {
            Deactivate();
        }
    }
}
