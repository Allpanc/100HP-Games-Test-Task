using TestTask100HPGames.Base;
using TestTask100HPGames.Enemy.Spawn;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TestTask100HPGames
{
    public class Game : MonoBehaviour
    {
        private AppStateMachine _stateMachine;

        private Tower _tower;
        private EnemySpawner _enemySpawner;
        private CountdownDisplay _countdownDisplay;

        [Inject]
        private void Construct(Tower tower, EnemySpawner enemySpawner, CountdownDisplay countdownDisplay)
        {
            _tower = tower;
            _enemySpawner = enemySpawner;
            _countdownDisplay = countdownDisplay;
            _tower.OnReached += Lose;
        }

        void Start()
        {
            _stateMachine = new AppStateMachine(_tower, _enemySpawner, _countdownDisplay);
            _stateMachine.SetState(AppState.Start);
        }

        public void Pause()
        {
            _stateMachine.SetState(AppState.Pause);
        }

        public void Resume()
        {
            _stateMachine.SetState(AppState.Game);
        }

        public void Restart()
        {
            string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);
        }

        private void Lose()
        {
            _stateMachine.SetState(AppState.Lose);
        }

        private void OnDestroy()
        {
            _tower.OnReached -= Lose;
        }
    }
}
