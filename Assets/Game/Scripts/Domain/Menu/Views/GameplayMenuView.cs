using EisvilTest.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace EisvilTest
{
    public class GameplayMenuView : MenuView
    {
        [Header("References")]
        [SerializeField] private ChallengeDisplay _challengeDisplay1;
        [SerializeField] private ChallengeDisplay _challengeDisplay2;
        [SerializeField] private ChallengeDisplay _challengeDisplay3;
        
        [field: SerializeField] public Button ExitButton { get; private set; }

        private ChallengesController _challengesController;

        public override void Enable()
        {
            _challengesController = Injector.Get<ChallengesController>();

            _challengeDisplay1.Initialize(_challengesController.Challenge1);
            _challengeDisplay2.Initialize(_challengesController.Challenge2);
            _challengeDisplay3.Initialize(_challengesController.Challenge3);

            ExitButton.onClick.AddListener(() => OnExitButtonClick());
        }

        public override void Disable()
        {
            _challengeDisplay1.Destroy();
            _challengeDisplay2.Destroy();
            _challengeDisplay3.Destroy();

            ExitButton.onClick.RemoveListener(() => OnExitButtonClick());
        }

        private void OnExitButtonClick()
        {
            _menuStateMachine.SetState(_menuStateMachine.MainMenuState);
        }
    }
}