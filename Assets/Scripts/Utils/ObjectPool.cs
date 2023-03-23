using System.Collections.Generic;
using UnityEngine;

namespace TestTask100HPGames.Utils
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] 
        private List<PooledObject> _pooledObjects;

        [SerializeField] 
        private PooledObject _objectToPool;

        [SerializeField] 
        private int _amountToPool;

        private void Start()
        {
            PooledObject tmp;
            for (int i = 0; i < _amountToPool; i++)
            {
                tmp = Instantiate(_objectToPool);
                tmp.Pool = this;
                tmp.gameObject.SetActive(false);
                _pooledObjects.Add(tmp);
            }
        }

        public PooledObject Get()
        {
            for (int i = 0; i < _amountToPool; i++)
            {
                if (!_pooledObjects[i].gameObject.activeInHierarchy)
                    return _pooledObjects[i];
            }
            return null;
        }

        public void Release(PooledObject objectToRelease, float releaseTime = 0)
        {
            if (_pooledObjects.Contains(objectToRelease))
            {
                objectToRelease.gameObject.SetActive(false);
            }
        }
    }
}
