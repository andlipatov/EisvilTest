namespace EisvilTest
{
    public class MainMenuState : MenuState
    {
        public override void Initialize()
        {
            _menuStateMachine.StartMenuState.Exited += StartMenuState_OnExited;
            _menuStateMachine.GameplayMenuState.Exited += GameplayMenuState_OnExited;
        }

        private void StartMenuState_OnExited()
        {
            _levelSystem.CreateLevel(LevelType.Menu);
            _menuSystem.CreateMenu<MainMenuView>();
        }

        private void GameplayMenuState_OnExited()
        {
            _levelSystem.CreateLevel(LevelType.Menu);
            _menuSystem.DestroyMenu<GameplayMenuView>();
            _menuSystem.CreateMenu<MainMenuView>();
        }

        public override void Exit()
        {
            _levelSystem.DestroyLevel();

            OnExited();
        }
    }
}