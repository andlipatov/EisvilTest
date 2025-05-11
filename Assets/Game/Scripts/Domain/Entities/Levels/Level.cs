using EisvilTest.Framework;
using UnityEngine;

namespace EisvilTest
{
    public class Level : MonoBehaviour
    {
        private LevelSystem _levelSystem;

        private EnemiesSpawner _enemiesSpawner;
        private EnemiesController _enemiesController;
        private TimerController _timerController;
        private ChallengesController _challengesController;

        private void Update()
        {
            if (_levelSystem.LevelType == LevelType.Gameplay)
            {
                _timerController.Update(Time.deltaTime);
            }
        }

        public void Initialize()
        {
            _levelSystem = Injector.Get<LevelSystem>();

            _enemiesSpawner = new EnemiesSpawner();
            _enemiesSpawner.Spawn();

            if (_levelSystem.LevelType == LevelType.Gameplay)
            {
                _enemiesController = new EnemiesController();
                _timerController = new TimerController();
                _challengesController = new ChallengesController(_enemiesController, _timerController);

                _enemiesController.Initialize();
                _timerController.Initialize();
                _challengesController.Initialize();
            }
        }

        public void Destroy()
        {
            if (_levelSystem.LevelType == LevelType.Gameplay)
            {
                _enemiesController.Destroy();
                _challengesController.Destroy();
            }

            Destroy(gameObject);
        }
    }
}