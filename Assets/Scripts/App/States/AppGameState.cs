namespace TestTask100HPGames
{
    public class AppGameState : AppBaseState
    {

        public override void Initialize(Game app)
        {
            base.Initialize(app);
        }

        public override void Enter()
        {
            base.Enter();
            _app.Tower.StartAttack();
            _app.EnemySpawner.Activate();
        }

        public override void Exit()
        {
            base.Exit();
            _app.EnemySpawner.Deactivate();
            _app.Tower.FinishAttack();
        }
    }
}
