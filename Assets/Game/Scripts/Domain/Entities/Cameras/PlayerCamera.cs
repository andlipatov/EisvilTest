using EisvilTest.Framework;
using UnityEngine;

namespace EisvilTest
{
    public class PlayerCamera : MonoBehaviour, ICamera
    {
        private Transform _playerTransform;
        private Transform _cameraTransform;

        public void LateUpdate()
        {
            transform.position = _cameraTransform.position;
            transform.rotation = _playerTransform.rotation;
        }

        public void Initialize()
        {
            Injector.Bind(this);
        }

        public void Destroy()
        {
            Injector.Unbind(this);
            Destroy(gameObject);
        }

        public void SetTransforms(Transform playerTransform, Transform cameraTransform)
        {
            _playerTransform = playerTransform;
            _cameraTransform = cameraTransform;
        }
    }
}