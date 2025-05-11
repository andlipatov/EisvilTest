using EisvilTest.Framework;
using UnityEngine;

namespace EisvilTest
{
    public class LevelEntities : MonoBehaviour, IEntities
    {
        [Header("Prefabs")]
        [SerializeField] private Level _levelPrefab;

        private Level _level;

        public void Initialize()
        {
            Injector.Bind(this);
        }

        public void Create()
        {
            _level = Instantiate(_levelPrefab, transform);
            _level.Initialize();
        }

        public void Destroy()
        {
            _level.Destroy();
        }
    }
}