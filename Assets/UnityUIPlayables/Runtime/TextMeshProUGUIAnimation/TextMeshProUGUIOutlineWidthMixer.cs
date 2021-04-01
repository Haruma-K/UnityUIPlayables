using TMPro;
using UnityEngine;

namespace UnityUIPlayables
{
    public class TextMeshProUGUIOutlineWidthMixer
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
            // Only at runtime, as a material instance will be created.
            if (!Application.isPlaying)
            {
                return;
            }

            if (_totalWeight == 0)
            {
                return;
            }

            _blendedValue += binding.fontSize * (1f - _totalWeight);
            binding.outlineWidth = _blendedValue;
        }
    }
}