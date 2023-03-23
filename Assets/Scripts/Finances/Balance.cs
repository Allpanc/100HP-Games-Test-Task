using System;

namespace TestTask100HPGames.Finances
{
    public class Balance
    {
        public int Coins { get; private set; }
        public event Action OnChanged;

        public static Balance Instance { get; private set; } = new Balance(0);

        private Balance(int coins)
        {
            Coins = coins;
        }

        public void Add(int amount)
        {
            Coins += amount;
            OnChanged?.Invoke();
        }

        public void Remove(int amount)
        {
            if (Coins >= amount)
            {
                Coins -= amount;
                OnChanged?.Invoke();
            }
        }

        public void Refresh()
        {
            Coins = 0;
        }
    }
}
