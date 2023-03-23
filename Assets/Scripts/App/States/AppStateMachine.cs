namespace TestTask100HPGames
{
    public class AppStateMachine
    {
        private AppBaseState _currentState = new AppBaseState();

        private AppStartState _startState =  new AppStartState();
        private AppGameState _gameState =  new AppGameState();
        private AppLoseState _loseState = new AppLoseState();
        private AppWinState _winState =  new AppWinState();
        private AppPauseState _pauseState =  new AppPauseState();

        public void Initialize(Game app)
        {
            InitializeStates(app);
            _startState.OnCountdownEnded += StartGame;
        }

        public void SetState(AppState state)
        {
            _currentState.Exit();

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

        public void StartGame()
        {
            SetState(AppState.Game);
        }

        private void InitializeStates(Game app)
        {
            _startState.Initialize(app);
            _gameState.Initialize(app);
            _loseState.Initialize(app);
            _winState.Initialize(app);
            _pauseState.Initialize(app);
        }
    }
}