using EisvilTest.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EisvilTest
{
    public class InputSystem : MonoBehaviour
    {
        private Actions _actions;
        private IControllable _controllable;

        private bool _isEnable;

        private void Update()
        {
            OnMove();
            OnLook();
        }

        public void Initialize()
        {
            Injector.Bind(this);

            _actions = new Actions();
            _actions.Player.Shoot.performed += OnShoot;
        }

        public void SetControllable(IControllable controllable)
        {
            _controllable = controllable;
        }

        public void SetEnable(bool value)
        {
            _isEnable = value;

            if (_isEnable)
            {
                _actions.Player.Enable();
            }
            else
            {
                _actions.Player.Disable();
            }
        }

        private void OnMove()
        {
            if (_isEnable)
            {
                Vector2 direction = _actions.Player.Move.ReadValue<Vector2>();
                _controllable.HandleMove(direction);
            }
        }

        private void OnLook()
        {
            if (_isEnable)
            {
                _controllable.HandleLook(_actions.Player.Look.ReadValue<Vector2>());
            }
        }

        public void OnShoot(InputAction.CallbackContext context)
        {
            _controllable.HandleShoot();
        }
    }
}