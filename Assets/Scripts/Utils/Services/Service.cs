using UnityEngine;

namespace TestTask100HPGames.Utils.Services
{
    public class Service : MonoBehaviour , IService
    {
        protected virtual void Awake()
        {
            GameServicesProvider.Instance.Register(this);
        }

        protected virtual void OnDestroy()
        {
            GameServicesProvider.Instance.Unregister(this);
        }
    }
}
