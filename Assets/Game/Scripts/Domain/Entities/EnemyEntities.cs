using UnityEngine;

namespace EisvilTest
{
    public class EnemyEntities : MonoBehaviour, IEntities
    {
        [Header("References")]
        [SerializeField] private BlueEnemyPool _blueEnemyPool;
        [SerializeField] private RedEnemyPool _redEnemyPool;

        public void Initialize()
        {
            _blueEnemyPool.Create();
            _redEnemyPool.Create();
        }

        public void Create()
        {
            _blueEnemyPool.Initialize();
            _redEnemyPool.Initialize();
        }

        public void Destroy()
        {
            _blueEnemyPool.Clear();
            _redEnemyPool.Clear();
        }
    }
}