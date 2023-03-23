using UnityEngine;

namespace TestTask100HPGames
{
    public class AppPauseState : AppBaseState
    {
        public override void Initialize(Game app)
        {
            base.Initialize(app);
            Time.timeScale = 1;
        }

        public override void Enter()
        {
            base.Enter();
            Time.timeScale = 0;
        }

        public override void Exit()
        {
            base.Exit();
            Time.timeScale = 1;
        }
    }
}
