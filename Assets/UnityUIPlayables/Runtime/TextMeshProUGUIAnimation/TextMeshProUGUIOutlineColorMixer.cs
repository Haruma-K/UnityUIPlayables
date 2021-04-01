using TMPro;
using UnityEngine;

namespace UnityUIPlayables
{
    public class TextMeshProUGUIOutlineColorMixer
    {
        private Color _blendedValue;
        private float _totalWeight;

        public void SetupFrame()
        {
            _blendedValue = Color.clear;
            _totalWeight = 0.0f;
        }

        public void Blend(Color startValue, Color endValue, float inputWeight, float progress)
        {
            _blendedValue += Color.Lerp(startValue, endValue, progress) * inputWeight;
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

            _blendedValue += binding.color * (1f - _totalWeight);
            binding.outlineColor = _blendedValue;
        }
    }
}