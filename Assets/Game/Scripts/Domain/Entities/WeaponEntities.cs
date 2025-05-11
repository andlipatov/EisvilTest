using UnityEngine;

namespace EisvilTest
{
    public class WeaponEntities : MonoBehaviour, IEntities
    {
        [Header("References")]
        [SerializeField] private BulletPool _bulletPool;

        public void Initialize()
        {
            _bulletPool.Create();
        }

        public void Create()
        {
            _bulletPool.Initialize();
        }

        public void Destroy()
        {
            _bulletPool.Clear();
        }
    }
}