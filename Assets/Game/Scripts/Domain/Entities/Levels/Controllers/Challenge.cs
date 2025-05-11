using System;

namespace EisvilTest
{
    public class Challenge
    {
        private readonly string _text;
        private readonly int _target;

        private int _value;
        private bool _isCompleted;

        public event Action<int> TargetSet;
        public event Action<string> TextSet;
        public event Action<int> ValueСhanged;
        public event Action<bool> Completed;

        public Challenge(string text, int target)
        {
            _text = text;
            _target = target;

            _value = 0;
            _isCompleted = false;
        }
        
        public void OnInitialize()
        {
            TextSet?.Invoke(_text);
            TargetSet?.Invoke(_target);
            ValueСhanged?.Invoke(_value);
            Completed?.Invoke(_isCompleted);
        }

        public void SetValue(int value)
        {
            if (!_isCompleted)
            {
                _value = value;

                if (_value >= _target)
                {
                    _isCompleted = true;
                    Completed?.Invoke(_isCompleted);
                }

                ValueСhanged?.Invoke(_value);
            }
        }
    }
}