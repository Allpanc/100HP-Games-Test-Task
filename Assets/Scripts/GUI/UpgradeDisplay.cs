using System;
using System.Threading.Tasks;
using TestTask100HPGames.Base;
using TestTask100HPGames.Statistics;
using TestTask100HPGames.Statistics.Upgradings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestTask100HPGames.GUI
{
    public class UpgradeDisplay : MonoBehaviour
    {
        [SerializeField] 
        private Button _buttonUpgrade;

        [SerializeField]
        private TMP_Text _textPrice;

        [SerializeField]
        private TMP_Text _textLevel;

        public Stat Stat;

        private Tower _tower;
        private Upgrades _upgrades;

        public event Action OnUpdated;

        [Inject]
        private void Construct(Tower tower)
        {
            _tower = tower;
        }

        private void Start()
        {
            SetUpContent();
            _buttonUpgrade.onClick.AddListener(OnUpgradeButtonClick);
        }

        private void OnUpgradeButtonClick()
        {
            if (!_upgrades.IsAvaliable(Stat))
                return;

            _upgrades.Apply(Stat);
            SetLevelText();
            SetPriceText();
            OnUpdated?.Invoke();
        }

        private void SetLevelText()
        {
            Upgrade current = _upgrades.Current(Stat);
            _textLevel.text = "Level " + (current.Level + 1).ToString() ;
        }

        private void SetPriceText()
        {
            Upgrade next = _upgrades.Next(Stat);

            if (next != null)
                _textPrice.text = next.Cost.ToString();
            else
                _textPrice.text = "max";
        }

        private async void SetUpContent()
        {
            await GetUpgrades();
            _textPrice.text = _upgrades.Initial(Stat).Cost.ToString();
        }

        private async Task GetUpgrades()
        {
            await Task.Yield();
            _upgrades = _tower.Upgrades;
        }
    }
}
