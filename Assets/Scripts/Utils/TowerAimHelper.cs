using TestTask100HPGames.Base;
using TestTask100HPGames.Statistics;
using UnityEngine;

namespace TestTask100HPGames.Utils
{
    public static class TowerAimHelper
    {
        public static Vector3 GetClosestEnemyPosition(Tower tower, EnemyTracker enemyTracker)
        {
            if (enemyTracker.Closest != null)
                return enemyTracker.Closest.GetComponent<Collider>().ClosestPoint(tower.transform.position);
            else
            {
                float reach = tower.Stats.GetStat(Stat.Reach);
                Vector3 offset = Vector3.one * reach * 2;
                return tower.transform.position + offset;
            }
        }

        public static bool IsEnemyInReach(Tower tower, EnemyTracker enemyTracker)
        {
            float reach = tower.Stats.GetStat(Stat.Reach);
            return Vector3.Distance(GetClosestEnemyPosition(tower, enemyTracker), tower.transform.position) <= reach;
        }

        public static Vector3 GetShootingDirection(Tower tower, EnemyTracker enemyTracker, Vector3 startBulletPosition)
        {
            try
            {
                Vector3 closestEnemyPos = TowerAimHelper.GetClosestEnemyPosition(tower, enemyTracker);
                Vector3 shootingDirection = closestEnemyPos - startBulletPosition;
                return shootingDirection;
            }
            catch (System.NullReferenceException)
            {
                return Vector3.zero;
            }
        }
    }
}
