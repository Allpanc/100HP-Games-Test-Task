using System.Collections.Generic;
using UnityEngine;

namespace TestTask100HPGames.Statistics
{
    [System.Serializable]
    public class Stats
    {
        public List<StatInfo> stats = new List<StatInfo>();

        public float GetStat(Stat stat)
        {
            for (int i = 0; i < stats.Count; i++)
            {
                if (stats[i].Stat == stat)
                    return stats[i].Value;
            }

            Debug.Log($"No stat value found for {stat}");
            return 0;
        }

        public void SetStat(Stat stat, float value)
        {
            for (int i = 0; i < stats.Count; i++)
            {
                if (stats[i].Stat == stat)
                {
                    stats[i].Value = value;
                    return;
                }
            }
            Debug.Log($"No stat value found for {stat}");
        }
    }


}
