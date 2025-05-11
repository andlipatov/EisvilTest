using UnityEngine;

namespace EisvilTest
{
    public class EnemyController
    {
        private const float _VELOCITY = 1.6f;
        private const float _ROTATION = 5.0f;
        private const float _THRESHOLD = 0.1f;

        private readonly Transform _transform;

        private Vector3 _targetPosition;

        private State _state;

        private enum State
        {
            Idle,
            Move
        }

        public EnemyController(Transform transform)
        {
            _transform = transform;
        }

        public void Initialize()
        {
            Vector3 position = GetRandomPosition();
            float angle = Random.Range(0.0f, 360.0f);
            Quaternion rotation = Quaternion.Euler(0.0f, angle, 0.0f);

            _transform.SetPositionAndRotation(position, rotation);
        }

        public void Update()
        {
            switch (_state)
            {
                case State.Idle:
                {
                    _targetPosition = GetRandomPosition();
                    _state = State.Move;

                    break;
                }
                case State.Move:
                {
                    if (Vector3.Distance(_transform.position, _targetPosition) < _THRESHOLD)
                    {
                        _state = State.Idle;
                    }
                    else
                    {
                        Vector3 direction = (_targetPosition - _transform.position).normalized;
                        Quaternion rotation = Quaternion.LookRotation(direction);
                        _transform.rotation = Quaternion.Slerp(_transform.rotation, rotation, _ROTATION * Time.deltaTime);
                        _transform.position += _transform.forward * _VELOCITY * Time.deltaTime;
                    }

                    break;
                }
            }
        }

        private Vector3 GetRandomPosition()
        {
            float x = Random.Range(-LevelData.LevelBound.HalfWidth, LevelData.LevelBound.HalfWidth);
            float z = Random.Range(-LevelData.LevelBound.HalfLength, LevelData.LevelBound.HalfLength);

            return new Vector3(x, _transform.position.y, z);
        }
    }
}