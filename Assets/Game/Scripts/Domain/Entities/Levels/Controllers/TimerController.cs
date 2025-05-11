using System;

namespace EisvilTest
{
    public class TimerController
    {
        private float _time;

        public event Action<float> TimeСhanged;

        public void Initialize()
        {
            _time = 0.0f;
        }

        public void Update(float deltaTime)
        {
            _time += deltaTime;
            TimeСhanged?.Invoke(_time);
        }
    }
}