using System;
using TestTask100HPGames.Base;
using TestTask100HPGames.Enemy.States;
using TestTask100HPGames.Finances;
using TestTask100HPGames.Statistics;
using TestTask100HPGames.Utils;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace TestTask100HPGames.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Animator))]
    public class EnemyController : MonoBehaviour, IEnemy, IDamageable
    {
        private EnemyTracker _enemyTracker;
        private Tower _tower;

        [SerializeField]
        protected Stats _stats;

        protected Animator _animator;
        protected NavMeshAgent _agent;
        protected EnemyStateMachine _stateMachine =  new EnemyStateMachine();

        public event Action OnDead;

        [Inject]
        private void Construct(Tower tower, EnemyTracker enemyTracker)
        {
            _enemyTracker = enemyTracker;
            _tower = tower;
        }

        private void Start()
        {
            _stateMachine.Initialize(this, _tower);
            _stateMachine.SetState(EnemyState.Attack);

            _animator = GetComponent<Animator>();

            _agent = GetComponent<NavMeshAgent>();
            _agent.speed = _stats.GetStat(Stat.Speed);

            _enemyTracker.Enemies.Add(this);
        }

        public virtual void Attack() {}

        public virtual void TakeDamage(float damage) 
        {
            float health = _stats.GetStat(Stat.Health);

            health = Mathf.Max(0, health - damage);

            _stats.SetStat(Stat.Health, health);
            
            if (health == 0)
                Die();
        }

        public virtual void Die() 
        {
            OnDead?.Invoke();
            _enemyTracker.Enemies.RemoveAll(x => x._stats.GetStat(Stat.Health) == 0);
            Balance.Instance.Add((int)_stats.GetStat(Stat.Reward));
            Destroy(gameObject, 0.1f);
        }
    }
}
