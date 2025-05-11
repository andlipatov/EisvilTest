using EisvilTest.Framework;
using UnityEngine;

namespace EisvilTest
{
    public class MenuCamera : MonoBehaviour, ICamera
    {
        private string _NAME = "MenuCameraTarget";

        private float _RADIUS = 10.0f;
        private float _HEIGHT = 4.0f;
        private float _SPEED = 0.5f;

        private CameraEntities _cameraEntities;
        private Transform _target;
        private float _angle;

        private void Update()
        {
            _angle += _SPEED * Time.deltaTime;

            float x = _target.position.x + _RADIUS * Mathf.Cos(_angle);
            float z = _target.position.z + _RADIUS * Mathf.Sin(_angle);

            transform.position = new Vector3(x, _target.position.y + _HEIGHT, z);
            transform.LookAt(_target);
        }

        public void Initialize()
        {
            _cameraEntities = Injector.Get<CameraEntities>();

            GameObject target = new(_NAME);
            _target = target.transform;
            _target.parent = _cameraEntities.transform;
            _target.position = Vector3.zero;
        }

        public void Destroy()
        {
            Destroy(_target.gameObject);
            Destroy(gameObject);
        }


    }
}