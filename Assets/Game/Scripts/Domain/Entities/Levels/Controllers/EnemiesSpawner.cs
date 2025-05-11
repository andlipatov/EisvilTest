using EisvilTest.Framework;

namespace EisvilTest
{
    public class EnemiesSpawner
    {
        private readonly LevelSystem _levelSystem;
        private readonly BlueEnemyPool _blueEnemyPool;
        private readonly RedEnemyPool _redEnemyPool;

        public EnemiesSpawner()
        {
            _levelSystem = Injector.Get<LevelSystem>();
            _blueEnemyPool = Injector.Get<BlueEnemyPool>();
            _redEnemyPool = Injector.Get<RedEnemyPool>();
        }

        public void Spawn()
        {
            int blueEnemyCount = 0;
            int redEnemyCount = 0;

            switch (_levelSystem.LevelType)
            {
                case LevelType.Menu:
                {
                    blueEnemyCount = LevelData.EnemiesCount[0].Blue;
                    redEnemyCount = LevelData.EnemiesCount[0].Red;

                    break;
                }
                case LevelType.Gameplay:
                {
                    blueEnemyCount = LevelData.EnemiesCount[1].Blue;
                    redEnemyCount = LevelData.EnemiesCount[1].Red;

                    break;
                }
            }

            for (int i = 0; i < blueEnemyCount; i++)
            {
                BlueEnemy blueEnemy = _blueEnemyPool.Get();
                blueEnemy.Setup();
            }

            for (int i = 0; i < redEnemyCount; i++)
            {
                RedEnemy redEnemy = _redEnemyPool.Get();
                redEnemy.Setup();
            }
        }
    }
}