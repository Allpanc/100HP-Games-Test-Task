using TestTask100HPGames.Enemy;
using UnityEngine;

namespace TestTask100HPGames.Utils.Services
{
    public class AssetsProvider
    {
        private const string SkeletonName = "Skeleton";
        private const string OrcName = "Orc";
        private const string KnightName = "Knight";

        public Skeleton Skeleton()
        {
            return (Skeleton)GetResourse(SkeletonName);
        }

        public Orc Orc()
        {
            return (Orc)GetResourse(OrcName);
        }

        public Knight Knight()
        {
            return (Knight)GetResourse(KnightName);
        }

        private Object GetResourse(string name)
        {
            return Resources.Load(name);
        }
    }
}
