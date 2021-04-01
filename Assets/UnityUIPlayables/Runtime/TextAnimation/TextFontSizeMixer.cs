using UnityEngine;
using UnityEngine.UI;

namespace UnityUIPlayables
{
    public class TextFontSizeMixer
    {
        private int _blendedValue;
        private float _totalWeight;

        public void SetupFrame()
        {
            _blendedValue = 0;
            _totalWeight = 0.0f;
        }

        public void Blend(int startValue, int endValue, float inputWeight, float progress)
        {
            _blendedValue += (int) (Mathf.Lerp(startValue, endValue, progress) * inputWeight);
            _totalWeight += inputWeight;
        }

        public void ApplyFrame(Text binding)
        {
            if (_totalWeight == 0)
            {
                return;
            }

            _blendedValue += (int) (binding.fontSize * (1f - _totalWeight));
            binding.fontSize = _blendedValue;
        }
    }
}