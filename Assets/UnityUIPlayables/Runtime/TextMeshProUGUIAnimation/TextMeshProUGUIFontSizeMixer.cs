using TMPro;
using UnityEngine;

namespace UnityUIPlayables
{
    public class TextMeshProUGUIFontSizeMixer
    {
        private float _blendedValue;
        private float _totalWeight;

        public void SetupFrame()
        {
            _blendedValue = 0;
            _totalWeight = 0.0f;
        }

        public void Blend(float startValue, float endValue, float inputWeight, float progress)
        {
            _blendedValue += Mathf.Lerp(startValue, endValue, progress) * inputWeight;
            _totalWeight += inputWeight;
        }

        public void ApplyFrame(TextMeshProUGUI binding)
        {
            if (_totalWeight == 0)
            {
                return;
            }

            _blendedValue += binding.fontSize * (1f - _totalWeight);
            binding.fontSize = _blendedValue;
        }
    }
}