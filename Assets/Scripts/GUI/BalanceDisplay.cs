using TestTask100HPGames.Finances;
using TMPro;
using UnityEngine;

namespace TestTask100HPGames.GUI
{
    public class BalanceDisplay : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _textBalance;

        void Start()
        {
            Balance.Instance.OnChanged += UpdateContent;
            UpdateContent();
        }

        private void UpdateContent()
        {
            _textBalance.text = Balance.Instance.Coins.ToString();
        }
    }
}
