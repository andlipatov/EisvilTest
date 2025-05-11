using UnityEngine;
using UnityEngine.UI;

namespace EisvilTest
{
    public class MainMenuView : MenuView
    {
        [Header("References")]
        [field: SerializeField] public Button PlayButton { get; private set; }

        public override void Enable()
        {
            PlayButton.onClick.AddListener(() => OnPlayButtonClick());
        }

        public override void Disable()
        {
            PlayButton.onClick.RemoveListener(() => OnPlayButtonClick());
        }

        private void OnPlayButtonClick()
        {
            _menuStateMachine.SetState(_menuStateMachine.GameplayMenuState);
        }
    }
}