using TestTask100HPGames.Base;
using TestTask100HPGames.Enemy.Spawn;

namespace TestTask100HPGames
{
    public class AppGameState : AppBaseState
    {
        private AppStateMachine _stateMachine;
        private Tower _tower;
        private EnemySpawner _enemySpawner;

        public AppGameState(AppStateMachine stateMachine, Tower tower, EnemySpawner enemySpawner)
        {
            _stateMachine = stateMachine;
            _tower = tower;
            _enemySpawner = enemySpawner;
        }

        public override void Enter()
        {
            base.Enter();
            _tower.StartAttack();
            _enemySpawner.Activate();
        }

        public override void Exit()
        {
            base.Exit();
            _enemySpawner.Deactivate();
            _tower.FinishAttack();
        }
    }
}
