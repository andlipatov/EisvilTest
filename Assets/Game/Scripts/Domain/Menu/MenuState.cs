using System;
using EisvilTest.Framework;

namespace EisvilTest
{
    public abstract class MenuState
    {
        protected InputSystem _inputSystem;
        protected LevelSystem _levelSystem;
        protected MenuSystem _menuSystem;
        protected MenuStateMachine _menuStateMachine;

        public event Action Exited;

        public MenuState()
        {
            _inputSystem = Injector.Get<InputSystem>();
            _levelSystem = Injector.Get<LevelSystem>();
            _menuSystem = Injector.Get<MenuSystem>();
            _menuStateMachine = Injector.Get<MenuStateMachine>();
        }

        public virtual void Initialize()
        {
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        protected virtual void OnExited()
        {
            Exited?.Invoke();
        }
    }
}