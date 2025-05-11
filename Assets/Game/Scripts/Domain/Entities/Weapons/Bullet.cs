using EisvilTest.Framework;
using UnityEngine;

namespace EisvilTest
{
    public class Bullet : PooledObject<Bullet>
    {
        private const float _MIN_FORCE = 35.0f;
        private const float _MAX_FORCE = 40.0f;

        private const float _Y_THRESHOLD = -20.0f;

        [Header("Physics")]
        [SerializeField] private Rigidbody _rigidbody;

        private void FixedUpdate()
        {
            if (transform.position.y < _Y_THRESHOLD)
            {
                Release();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage();
            }

            Release();
        }

        public void Setup(Vector3 position, Quaternion rotation, Vector3 velocity)
        {
            transform.position = position;

            Vector3 force = rotation * Vector3.forward * Random.Range(_MIN_FORCE, _MAX_FORCE);
            _rigidbody.linearVelocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
            _rigidbody.AddForce(force + velocity, ForceMode.Impulse);
        }
    }
}