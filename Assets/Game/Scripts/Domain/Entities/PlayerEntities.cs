using EisvilTest.Framework;
using UnityEngine;

namespace EisvilTest
{
    public class PlayerEntities : MonoBehaviour, IEntities
    {
        [Header("Prefabs")]
        [SerializeField] private Player _playerPrefab;

        private LevelSystem _levelSystem;

        private Player _player;

        public void Initialize()
        {
            _levelSystem = Injector.Get<LevelSystem>();
        }

        public void Create()
        {
            if (_levelSystem.LevelType == LevelType.Gameplay)
            {
                _player = Instantiate(_playerPrefab, LevelData.PlayerPosition, Quaternion.identity, transform);
                _player.Initialize();
            }
        }

        public void Destroy()
        {
            if (_levelSystem.LevelType == LevelType.Gameplay)
            {
                _player.Destroy();
            }
        }
    }
}