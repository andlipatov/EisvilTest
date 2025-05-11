using EisvilTest.Framework;
using UnityEngine;

namespace EisvilTest
{
    public class Player : MonoBehaviour, IControllable
    {
        [Header("Components")]
        [SerializeField] private Transform _cameraTransform;
        [SerializeField] private Transform _shootTransform;

        [Header("Physics")]
        [SerializeField] private Rigidbody _rigidbody;

        private InputSystem _inputSystem;
        private PlayerCamera _playerCamera;

        private MoveController _moveController;
        private LookController _lookController;
        private ShootController _shootController;

        private void FixedUpdate()
        {
            _moveController.Update();
            _lookController.Update();
        }

        public void Initialize()
        {
            _inputSystem = Injector.Get<InputSystem>();
            _inputSystem.SetControllable(this);

            _playerCamera = Injector.Get<PlayerCamera>();
            _playerCamera.SetTransforms(transform, _cameraTransform);

            _moveController = new MoveController(transform);
            _lookController = new LookController(transform);
            _shootController = new ShootController(_shootTransform, _rigidbody);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        public void HandleMove(Vector2 direction)
        {
            _moveController.HandleMove(direction);
        }

        public void HandleLook(Vector2 direction)
        {
            _lookController.HandleLook(direction);
        }

        public void HandleShoot()
        {
            _shootController.HandleShoot();
        }
    }
}