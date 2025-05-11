using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace EisvilTest
{
    public class ChallengeDisplay : MonoBehaviour
    {
        private const int _NORMAL_FRAME = 0;
        private const int _COMPLETED_FRAME = 1;

        [Header("Components")]
        [SerializeField] private TMP_Text _text;

        [Header("Render")]
        [SerializeField] private RectMask2D _rectMask;

        [SerializeField] private Image _iconImage;
        [SerializeField] private Image _fillImage;
        [SerializeField] private Image _backgroundImage;

        [SerializeField] private Sprite[] _iconSprites;
        [SerializeField] private Sprite[] _fillSprites;
        [SerializeField] private Sprite[] _backgroundSprites;

        private Challenge _challenge;

        private float _width;

        private int _target;
        private int _value;
        private bool _isCompleted;

        public void Initialize(Challenge challenge)
        {
            _challenge = challenge;

            _width = _rectMask.rectTransform.rect.width;

            _challenge.TextSet += OnTextSet;
            _challenge.TargetSet += OnTargetSet;
            _challenge.ValueСhanged += OnValueСhanged;
            _challenge.IsCompletedСhanged += OnIsCompletedСhanged;

            _challenge.OnInitialize();
        }

        public void Destroy()
        {
            _challenge.TextSet -= OnTextSet;
            _challenge.TargetSet -= OnTargetSet;
            _challenge.ValueСhanged -= OnValueСhanged;
            _challenge.IsCompletedСhanged -= OnIsCompletedСhanged;
        }

        private void OnTextSet(string text)
        {
            _text.text = text;
        }

        private void OnTargetSet(int target)
        {
            _target = target;
        }

        private void OnValueСhanged(int value)
        {
            _value = value;
            _rectMask.padding = new Vector4(0.0f, 0.0f, _width * (1.0f - (float)_value / _target), 0.0f);
        }

        private void OnIsCompletedСhanged(bool isCompleted)
        {
            _isCompleted = isCompleted;

            if (_isCompleted)
            {
                _iconImage.sprite = _iconSprites[_COMPLETED_FRAME];
                _fillImage.sprite = _fillSprites[_COMPLETED_FRAME];
                _backgroundImage.sprite = _backgroundSprites[_COMPLETED_FRAME];
            }
            else
            {
                _iconImage.sprite = _iconSprites[_NORMAL_FRAME];
                _fillImage.sprite = _fillSprites[_NORMAL_FRAME];
                _backgroundImage.sprite = _backgroundSprites[_NORMAL_FRAME];
            }
        }
    }
}