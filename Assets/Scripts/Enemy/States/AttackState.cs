using TestTask100HPGames.Base;
using UnityEngine;

namespace TestTask100HPGames.Enemy.States
{
    public class AttackState : EnemyBaseState
    {
        private Tower _tower;

        public AttackState(Tower tower)
        {
            _tower = tower;
        }
 
        public override void Enter()
        {
            Vector3 towerPosition = _tower.transform.position;
            _agent.SetDestination(towerPosition);
        }
    }
}
