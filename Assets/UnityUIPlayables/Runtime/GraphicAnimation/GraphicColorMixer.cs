using UnityEngine;
using UnityEngine.UI;

namespace UnityUIPlayables
{
    public class GraphicColorMixer
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

        public void ApplyFrame(Graphic binding)
        {
            _blendedValue += binding.color * (1f - _totalWeight);
            binding.color = _blendedValue;
        }
    }
}