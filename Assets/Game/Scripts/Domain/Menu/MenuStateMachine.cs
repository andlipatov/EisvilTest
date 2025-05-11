using EisvilTest.Framework;

namespace EisvilTest
{
    public class MenuStateMachine
    {
        public MenuState StartMenuState { get; private set; }
        public MenuState MainMenuState { get; private set; }
        public MenuState GameplayMenuState { get; private set; }

        private MenuState _prevState;
        private MenuState _currentState;

        public MenuStateMachine()
        {
            Injector.Bind(this);

            StartMenuState = new StartMenuState();
            MainMenuState = new MainMenuState();
            GameplayMenuState = new GameplayMenuState();

            StartMenuState.Initialize();
            MainMenuState.Initialize();
            GameplayMenuState.Initialize();

            _currentState = StartMenuState;
        }

        public void SetState(MenuState state)
        {
            _prevState = _currentState;
            _currentState = state;

            _prevState.Exit();
            _currentState.Enter();
        }
    }
}