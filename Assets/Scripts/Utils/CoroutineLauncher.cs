using System.Collections;
using UnityEngine;

namespace TestTask100HPGames.Utils
{
    public sealed class CoroutineLauncher : MonoBehaviour
    {
        private static CoroutineLauncher instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject go = new GameObject("[COROUTINE LAUNCHER]");
                    _instance = go.AddComponent<CoroutineLauncher>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        private static CoroutineLauncher _instance;

        public static Coroutine StartRoutine(IEnumerator enumerator)
        {
            return instance.StartCoroutine(enumerator);
        }

        public static void StopRoutine(Coroutine routine)
        {
            instance.StopCoroutine(routine);
        }
    }
}
