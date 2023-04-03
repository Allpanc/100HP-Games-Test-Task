using System.Collections;
using TestTask100HPGames.Finances;
using TestTask100HPGames.Utils;
using UnityEngine;

namespace TestTask100HPGames
{
    public class AppStartState : AppBaseState
    {
        private AppStateMachine _stateMachine;
        private CountdownDisplay _countdownDisplay;

        public AppStartState(AppStateMachine stateMachine, CountdownDisplay countdownDisplay)
        {
            _stateMachine = stateMachine;
            _countdownDisplay = countdownDisplay;
        }

        public override void Enter()
        {
            base.Enter();
            Balance.Instance.Refresh();
            CoroutineLauncher.StartRoutine(Countdown()); 
        }

        private IEnumerator Countdown()
        {
            int timer = 3;

            _countdownDisplay.UpdateView(timer);

            while (timer > 0)
            {
                yield return new WaitForSeconds(1);

                timer--;
                _countdownDisplay.UpdateView(timer);
            }

            yield return new WaitForSeconds(1);

            _countdownDisplay.Hide();
            _stateMachine.SetState(AppState.Game);
        }
    }
}
