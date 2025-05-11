using UnityEngine;

namespace EisvilTest
{
    public class LookController
    {
        private const float _ROTATION_SPEED = 0.5f;

        private readonly Transform _transform;

        private Vector2 _inputDirection;
        private float _rotationVelocity;

        public LookController(Transform transform)
        {
            _transform = transform;
        }

        public void Update()
        {
            _rotationVelocity = _inputDirection.x * _ROTATION_SPEED;
            _transform.Rotate(Vector3.up * _rotationVelocity);
        }

        public void HandleLook(Vector2 direction)
        {
            _inputDirection = direction;
        }
    }
}