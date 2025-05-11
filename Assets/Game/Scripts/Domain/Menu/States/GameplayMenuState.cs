namespace EisvilTest
{
    public class GameplayMenuState : MenuState
    {
        public override void Initialize()
        {
            _menuStateMachine.MainMenuState.Exited += MainMenuState_OnExited;
        }

        private void MainMenuState_OnExited()
        {
            _levelSystem.CreateLevel(LevelType.Gameplay);
            _menuSystem.DestroyMenu<MainMenuView>();
            _menuSystem.CreateMenu<GameplayMenuView>();
            _inputSystem.SetEnable(true);
        }

        public override void Exit()
        {
            _inputSystem.SetEnable(false);
            _levelSystem.DestroyLevel();

            OnExited();
        }
    }
}