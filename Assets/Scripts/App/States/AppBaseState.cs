namespace TestTask100HPGames
{
    public class AppBaseState : IAppState
    {
        protected Game _app;

        public virtual void Initialize(Game app)
        {
            _app = app;
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
