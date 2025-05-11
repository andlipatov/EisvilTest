using System;

namespace EisvilTest
{
    public class EnemiesController
    {
        private int _blueEnemyDeathCount;
        private int _redEnemyDeathCount;

        public event Action<int> EnemyDeathCountСhanged;
        public event Action<int> BlueEnemyDeathCountСhanged;
        public event Action<int> RedEnemyDeathCountСhanged;

        public EnemiesController()
        {
            BlueEnemy.Died += BlueEnemy_OnDied;
            RedEnemy.Died += RedEnemy_OnDied;
        }

        public void Initialize()
        {
            _blueEnemyDeathCount = 0;
            _redEnemyDeathCount = 0;
        }

        public void Destroy()
        {
            BlueEnemy.Died -= BlueEnemy_OnDied;
            RedEnemy.Died -= RedEnemy_OnDied;
        }

        private void BlueEnemy_OnDied()
        {
            _blueEnemyDeathCount++;

            EnemyDeathCountСhanged?.Invoke(_blueEnemyDeathCount + _redEnemyDeathCount);
            BlueEnemyDeathCountСhanged?.Invoke(_blueEnemyDeathCount);
        }

        private void RedEnemy_OnDied()
        {
            _redEnemyDeathCount++;

            EnemyDeathCountСhanged?.Invoke(_blueEnemyDeathCount + _redEnemyDeathCount);
            RedEnemyDeathCountСhanged?.Invoke(_redEnemyDeathCount);
        }
    }
}