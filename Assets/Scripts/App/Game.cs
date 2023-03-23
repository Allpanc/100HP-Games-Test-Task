using TestTask100HPGames.Base;
using TestTask100HPGames.Enemy.Spawn;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TestTask100HPGames
{
    public class Game : MonoBehaviour
    {
        private AppStateMachine _stateMachine =  new AppStateMachine();

        public Tower Tower { get; private set; }
        public EnemySpawner EnemySpawner { get; private set; }

        [Inject]
        private void Construct(Tower tower, EnemySpawner enemySpawner)
        {
            Tower = tower;
            EnemySpawner = enemySpawner;
            Tower.OnReached += Lose;
        }

        void Start()
        {
            _stateMachine.Initialize(this);
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
            Tower.OnReached -= Lose;
        }
    }
}
