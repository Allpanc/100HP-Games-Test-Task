using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace TestTask100HPGames
{
    public class CountdownDisplay : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _textCountdown;

        void Start()
        {
            MakeCountdown();
        }

        private async void MakeCountdown()
        {
            await Countdown();
        }

        private async Task Countdown()
        {
            int timer = 3;
            _textCountdown.text = timer.ToString();

            while (timer > 0)
            {
                await Task.Delay(1000);
                timer--;
                
                if (timer == 0)
                    _textCountdown.text = "Fight!";
                else
                    _textCountdown.text = timer.ToString();
            }
            await Task.Delay(1000);
            _textCountdown.text = "";
        }
    }
}
