using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace TestTask100HPGames
{
    public class CountdownDisplay : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _textCountdown;

        public void UpdateView(int timer)
        {
            if (timer == 0)
                _textCountdown.text = "Fight!";
            else
                _textCountdown.text = timer.ToString();
        }

        public void Hide()
        {
            _textCountdown.text = "";
        }
    }
}
