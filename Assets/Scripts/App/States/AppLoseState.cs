using UnityEngine;

namespace TestTask100HPGames
{
    public class AppLoseState : AppBaseState
    {
        public override void Enter()
        {
            base.Enter();
            Time.timeScale = 0;
        }
    }
}
