using UnityEngine;

namespace EisvilTest
{
    public class MoveController
    {
        private const float _MOVE_SPEED = 10.0f;

        private readonly Transform _transform;

        private Vector2 _inputDirection;
        private Vector3 _moveDirection;

        public MoveController(Transform transform)
        {
            _transform = transform;
        }

        public void Update()
        {
            _moveDirection = _transform.right * _inputDirection.x + _transform.forward * _inputDirection.y;
            _transform.position += _MOVE_SPEED * Time.deltaTime * _moveDirection;
        }

        public void HandleMove(Vector2 direction)
        {
            _inputDirection = direction;
        }
    }
}