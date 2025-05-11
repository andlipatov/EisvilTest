using System;
using EisvilTest.Framework;

namespace EisvilTest
{
    public class RedEnemy : PooledObject<RedEnemy>, IEnemy, IDamageable
    {
        private EnemyController _enemyController;

        public static event Action Died;

        private void Awake()
        {
            _enemyController = new EnemyController(transform);
        }

        private void Update()
        {
            _enemyController.Update();
        }

        public void Setup()
        {
            _enemyController.Initialize();
        }

        public void TakeDamage()
        {
            Died?.Invoke();
            Release();
        }
    }
}