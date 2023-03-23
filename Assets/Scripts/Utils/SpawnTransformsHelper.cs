using TestTask100HPGames.Base;
using UnityEngine;
using Random = UnityEngine.Random;

namespace TestTask100HPGames.Utils
{
    public static class SpawnTransformsHelper
    {
        public static Vector3 CenterPos;

        public static Vector3 GetSpawnPosition(float spawnRadius)
        {
            float angle = Random.Range(0, 2 * Mathf.PI);

            float spawnX = CenterPos.x + spawnRadius * Mathf.Sin(angle);
            float spawnZ = CenterPos.z + spawnRadius * Mathf.Cos(angle);

            Vector3 spawnPos = new Vector3(spawnX, 0, spawnZ);

            return spawnPos;
        }

        public static Quaternion GetSpawnRotation(Vector3 spawnPosition)
        {
            return Quaternion.LookRotation(CenterPos - spawnPosition);
        }
    }
}
