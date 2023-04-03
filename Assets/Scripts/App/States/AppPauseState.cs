using UnityEngine;

namespace TestTask100HPGames
{
    public class AppPauseState : AppBaseState
    {
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
