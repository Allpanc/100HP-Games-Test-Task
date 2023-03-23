using TestTask100HPGames.Base;

namespace TestTask100HPGames.Enemy.States
{
    public class EnemyStateMachine
    {
        private EnemyBaseState _currentState = new EnemyBaseState();

        private AttackState _attackState;
        private IdleState _idleState =  new IdleState();

        private Tower _tower;

        public void Initialize(EnemyController enemy, Tower tower)
        {
            _tower = tower;
            InitializeStates(enemy);
        }

        public void SetState(EnemyState state)
        {
            _currentState.Exit();

            switch (state)
            {
                case EnemyState.Idle:
                    _currentState = _idleState;
                    break;
                case EnemyState.Attack:
                    _currentState = _attackState;
                    break;
            }

            _currentState.Enter();
        }

        private void InitializeStates(EnemyController enemy)
        {
            _attackState = new AttackState(_tower);
            _attackState.Initialize(enemy);
            _idleState.Initialize(enemy);
        }
    }
}
