using UnityEngine;
using UnityEngine.AI;

namespace TestTask100HPGames.Enemy.States
{
    public class EnemyBaseState : IEnemyState
    {
        EnemyController _enemy;
        protected Animator _animator;
        protected NavMeshAgent _agent;

        public virtual void Initialize(EnemyController enemy)
        {
            _enemy = enemy;
            _animator = enemy.GetComponent<Animator>();
            _agent = enemy.GetComponent<NavMeshAgent>();
        }

        public virtual void Enter()
        {
        }

        public virtual void Tick()
        {
        }

        public virtual void Exit()
        {
        }
    }
}
