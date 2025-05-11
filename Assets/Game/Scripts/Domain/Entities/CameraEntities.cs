using EisvilTest.Framework;
using UnityEngine;

namespace EisvilTest
{
    public class CameraEntities : MonoBehaviour, IEntities
    {
        [Header("Prefabs")]
        [SerializeField] private MenuCamera _menuCameraPrefab;
        [SerializeField] private PlayerCamera _playerCameraPrefab;

        private ICamera _camera;

        private LevelSystem _levelSystem;

        public void Initialize()
        {
            Injector.Bind(this);
            _levelSystem = Injector.Get<LevelSystem>();
        }

        public void Create()
        {
            switch (_levelSystem.LevelType)
            {
                case LevelType.Menu:
                {
                    _camera = Instantiate(_menuCameraPrefab, transform);
                    break;
                }
                case LevelType.Gameplay:
                {
                    _camera = Instantiate(_playerCameraPrefab, transform);
                    break;
                }
            }

            _camera.Initialize();
        }

        public void Destroy()
        {
            _camera.Destroy();
        }
    }
}