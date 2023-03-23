using System.Collections;
using TestTask100HPGames.Statistics;
using TestTask100HPGames.Utils;
using UnityEngine;
using Zenject;

namespace TestTask100HPGames.Base.Shooting
{
    public class ShootingSystem : MonoBehaviour
    {
        [SerializeField] 
        private float _shootingForce = 5;

        [SerializeField] 
        private Transform _startBulletLocation;

        [SerializeField] 
        private Transform _rotatingBase;

        [SerializeField]
        float _rotationSpeed;

        private ObjectPool _pool;
        private Coroutine _shootingRoutine;
        private EnemyTracker _enemyTracker;
        private Tower _tower;

        public Vector3 ShootingDirection { get => TowerAimHelper.GetShootingDirection(_tower, _enemyTracker, _startBulletLocation.position); }

        [Inject]
        private void Construct(Tower tower, EnemyTracker enemyTracker, ObjectPool pool)
        {
            _tower = tower;
            _enemyTracker = enemyTracker;
            _pool = pool;
        }

        private void Update()
        {
            if (Vector3.Angle(_rotatingBase.forward, transform.position - _rotatingBase.position) > 1
                && TowerAimHelper.IsEnemyInReach(_tower, _enemyTracker))
                FaceClosestEnemy();
        }

        private void Fire()
        {
            Bullet bullet = _pool.Get().gameObject.GetComponent<Bullet>();
            if (bullet == null)
                return;

            bullet.gameObject.SetActive(true);
            bullet.Damage = _tower.Stats.GetStat(Stat.Damage);

            Vector3 shootingDirection = TowerAimHelper.GetShootingDirection(_tower, _enemyTracker, _startBulletLocation.position);

            bullet.transform.position = _startBulletLocation.position;
            bullet.GetComponent<Rigidbody>().freezeRotation = false;
            bullet.transform.forward = shootingDirection.normalized;
            bullet.GetComponent<Rigidbody>().freezeRotation = true;
            bullet.GetComponent<Rigidbody>().AddForce(shootingDirection * _shootingForce, ForceMode.Impulse);
        }

        public void StartShooting()
        {
            if (_shootingRoutine == null)
                _shootingRoutine = StartCoroutine(Shoot());
        }

        public void StopShooting()
        {
            if (_shootingRoutine != null)
            {
                StopCoroutine(_shootingRoutine);
                _shootingRoutine = null;
            }
        }

        private void FaceClosestEnemy()
        {
            Quaternion desiredRotation = Quaternion.LookRotation(TowerAimHelper.GetShootingDirection(_tower, _enemyTracker, _startBulletLocation.position));
            desiredRotation = Quaternion.Euler(0, desiredRotation.eulerAngles.y, 0);
            _rotatingBase.rotation = Quaternion.Lerp(_rotatingBase.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
        }

        private IEnumerator Shoot()
        {
            while (true)
            {
                float shootingSpeed = _tower.Stats.GetStat(Stat.ShootingSpeed);

                float timeBetweenShots = 1 / shootingSpeed;

                yield return new WaitForSeconds(timeBetweenShots);
                if (TowerAimHelper.IsEnemyInReach(_tower, _enemyTracker))
                    Fire();
            }
        }
    }
}
