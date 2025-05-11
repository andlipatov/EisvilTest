using EisvilTest.Framework;

namespace EisvilTest
{
    public class ChallengesController
    {
        private EnemiesController _enemiesController;
        private TimerController _timerController;

        public Challenge Challenge1 { get; private set; }
        public Challenge Challenge2 { get; private set; }
        public Challenge Challenge3 { get; private set; }

        public ChallengesController(EnemiesController enemiesController, TimerController timerController)
        {
            Injector.Bind(this);

            _enemiesController = enemiesController;
            _timerController = timerController;
        }

        public void Initialize()
        {
            Challenge1 = new Challenge(ChallengeData.Challenges[0].Text, ChallengeData.Challenges[0].Target);
            Challenge2 = new Challenge(ChallengeData.Challenges[1].Text, ChallengeData.Challenges[1].Target);
            Challenge3 = new Challenge(ChallengeData.Challenges[2].Text, ChallengeData.Challenges[2].Target);

            _timerController.TimeСhanged += OnTimeСhanged;
            _enemiesController.EnemyDeathCountСhanged += OnEnemyDeathCountСhanged;
            _enemiesController.BlueEnemyDeathCountСhanged += OnBlueEnemyDeathCountСhanged;
            _enemiesController.RedEnemyDeathCountСhanged += OnRedEnemyDeathCountСhanged;
        }

        public void Destroy()
        {
            _timerController.TimeСhanged -= OnTimeСhanged;
            _enemiesController.EnemyDeathCountСhanged -= OnEnemyDeathCountСhanged;
            _enemiesController.BlueEnemyDeathCountСhanged -= OnBlueEnemyDeathCountСhanged;
            _enemiesController.RedEnemyDeathCountСhanged -= OnRedEnemyDeathCountСhanged;

            Injector.Unbind(this);
        }

        private void OnTimeСhanged(float time)
        {
            Challenge1.SetValue((int)time);
        }

        private void OnEnemyDeathCountСhanged(int count)
        {
            Challenge2.SetValue(count);
        }

        private void OnBlueEnemyDeathCountСhanged(int count)
        {
        }

        private void OnRedEnemyDeathCountСhanged(int count)
        {
            Challenge3.SetValue(count);
        }
    }
}