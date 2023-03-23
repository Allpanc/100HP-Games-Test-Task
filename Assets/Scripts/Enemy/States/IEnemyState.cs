namespace TestTask100HPGames.Enemy
{
    public interface IEnemyState
    {
        public void Initialize(EnemyController enemy);
        public void Enter();
        public void Tick();
        public void Exit();
    }
}
