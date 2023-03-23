namespace TestTask100HPGames
{
    public interface IAppState
    {
        public void Initialize(Game app);
        public void Enter();
        public void Tick();
        public void Exit();
    }
}
