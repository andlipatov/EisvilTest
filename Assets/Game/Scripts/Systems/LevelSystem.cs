using EisvilTest.Framework;
using UnityEngine;

namespace EisvilTest
{
    public class LevelSystem : MonoBehaviour
    {
        [SerializeField] private LevelEntities _levelEntities;
        [SerializeField] private CameraEntities _cameraEntities;
        [SerializeField] private PlayerEntities _playerEntities;
        [SerializeField] private EnemyEntities _enemyEntities;
        [SerializeField] private WeaponEntities _weaponEntities;

        public LevelType LevelType { get; private set; }

        public void Initialize()
        {
            Injector.Bind(this);

            _levelEntities.Initialize();
            _cameraEntities.Initialize();
            _playerEntities.Initialize();
            _enemyEntities.Initialize();
            _weaponEntities.Initialize();
        }

        public void CreateLevel(LevelType levelType)
        {
            LevelType = levelType;

            _levelEntities.Create();
            _cameraEntities.Create();
            _playerEntities.Create();
            _enemyEntities.Create();
            _weaponEntities.Create();
        }

        public void DestroyLevel()
        {
            _weaponEntities.Destroy();
            _enemyEntities.Destroy();
            _playerEntities.Destroy();
            _cameraEntities.Destroy();
            _levelEntities.Destroy();
        }
    }
}