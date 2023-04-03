using TestTask100HPGames.Base;
using TestTask100HPGames.Enemy.Spawn;

namespace TestTask100HPGames
{
    public class AppStateMachine
    {
        private AppBaseState _currentState;

        private AppStartState _startState;
        private AppGameState _gameState;
        private AppLoseState _loseState;
        private AppWinState _winState;
        private AppPauseState _pauseState;

        private Tower _tower;
        private EnemySpawner _enemySpawner;
        private CountdownDisplay _countdownDisplay;

        public AppStateMachine(Tower tower, EnemySpawner enemySpawner, CountdownDisplay countdownDisplay)
        {
            _tower = tower;
            _enemySpawner = enemySpawner;
            _countdownDisplay = countdownDisplay;

            Initialize();
        }

        public void Initialize()
        {
            InitializeStates();
        }

        public void SetState(AppState state)
        {
            _currentState?.Exit();

            switch (state)
            {
                case AppState.Start:
                    _currentState = _startState;
                    break;
                case AppState.Game:
                    _currentState = _gameState;
                    break;
                case AppState.Win:
                    _currentState = _winState;
                    break;
                case AppState.Lose:
                    _currentState = _loseState;
                    break;
                case AppState.Pause:
                    _currentState = _pauseState;
                    break;
            }

            _currentState.Enter();
        }

        private void InitializeStates()
        {
            _startState =  new AppStartState(this, _countdownDisplay);
            _gameState = new AppGameState(this, _tower, _enemySpawner);
            _loseState = new AppLoseState();
            _winState =  new AppWinState();
            _pauseState = new AppPauseState();
        }
    }
}