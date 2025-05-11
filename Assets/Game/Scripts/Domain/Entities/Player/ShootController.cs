using EisvilTest.Framework;
using UnityEngine;

namespace EisvilTest
{
    public class ShootController
    {
        private readonly Transform _shootTransform;
        private readonly Rigidbody _rigidbody;

        private readonly BulletPool _bulletPool;

        public ShootController(Transform transform, Rigidbody rigidbody)
        {
            _shootTransform = transform;
            _rigidbody = rigidbody;

            _bulletPool = Injector.Get<BulletPool>();
        }

        internal void HandleShoot()
        {
            Bullet bullet = _bulletPool.Get();
            bullet.Setup(_shootTransform.position, _shootTransform.rotation, _rigidbody.linearVelocity);
        }
    }
}