using System;
using System.Threading.Tasks;
using TestTask100HPGames.Finances;
using UnityEngine;

namespace TestTask100HPGames
{
    public class AppStartState : AppBaseState
    {
        public event Action<int> OnCountdownChanged;
        public event Action OnCountdownEnded;

        public override void Enter()
        {
            base.Enter();
            WaitForCountdown();
            Balance.Instance.Refresh();
        }

        private async void WaitForCountdown()
        {
            await Countdown();
        }

        private async Task Countdown()
        {

            int timer = 3;
            Debug.Log(timer);
            while (timer > 0)
            {
                await Task.Delay(1000);
                timer--;
                Debug.Log(timer);
                OnCountdownChanged?.Invoke(timer);
            }
            OnCountdownEnded?.Invoke();
        }
    }
}
