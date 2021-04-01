using UnityEngine;
using UnityEngine.UI;

namespace UnityUIPlayables
{
    public class SliderValueMixer
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

        public void ApplyFrame(Slider binding)
        {
            if (_totalWeight == 0)
            {
                return;
            }

            _blendedValue += binding.value * (1f - _totalWeight);
            binding.value = _blendedValue;
        }
    }
}