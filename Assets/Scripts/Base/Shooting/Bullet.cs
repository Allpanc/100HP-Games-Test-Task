using System.Collections;
using TestTask100HPGames.Enemy;
using TestTask100HPGames.Utils;
using UnityEngine;

namespace TestTask100HPGames.Base.Shooting
{
    public class Bullet : PooledObject
    {
        [SerializeField] 
        private GameObject _explosionEffect;

        private Rigidbody _rb;

        public bool IsUsed;
        public float Damage;

        private void Start()
        {
            _rb = GetComponentInChildren<Rigidbody>();
        }

        private void OnEnable()
        {
            StartCoroutine(ReturnToPoolAfterTimeout());
            if (_rb == null)
                _rb = GetComponentInChildren<Rigidbody>();

            _rb.velocity = Vector3.zero;
            _rb.useGravity = false;
        }

        void OnCollisionEnter(Collision collision)
        {
            StartCoroutine(ReturnToPoolAfterCollision());

            _rb.useGravity = true;
            _rb.velocity = Vector3.zero;
            _explosionEffect.SetActive(true);
            if (collision.gameObject.GetComponent<IDamageable>() != null)
                collision.gameObject.GetComponent<IDamageable>().TakeDamage(Damage);
        }

        IEnumerator ReturnToPoolAfterCollision()
        {
            yield return new WaitForSeconds(0.5f);
            IsUsed = false;
            Pool.Release(this);
        }

        IEnumerator ReturnToPoolAfterTimeout()
        {
            yield return new WaitForSeconds(2f);
            IsUsed = false;
            Pool.Release(this);
        }
    }
}
