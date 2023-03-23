using TestTask100HPGames.Base;
using TestTask100HPGames.Enemy;
using UnityEngine;
using Zenject;

namespace TestTask100HPGames.Utils
{
    public class EnemyTracker : MonoBehaviour
    {
        public KdTree<EnemyController> Enemies = new KdTree<EnemyController>();
        public EnemyController Closest;
        private Tower _tower;

        [Inject]
        private void Construct(Tower tower)
        {
            _tower = tower;
        }

        private void Update()
        {
            Enemies.UpdatePositions();
            Closest = Enemies.FindClosest(_tower.transform.position);
        }
    }
}
