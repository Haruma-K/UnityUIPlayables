using TMPro;
using UnityEngine;

namespace UnityUIPlayables
{
    public class TextMeshProUGUIVertexGradientMixer
    {
        private Color _blendedBottomLeft;
        private Color _blendedBottomRight;
        private Color _blendedTopLeft;
        private Color _blendedTopRight;
        private float _totalWeight;

        public void SetupFrame()
        {
            _blendedTopLeft = Color.clear;
            _blendedTopRight = Color.clear;
            _blendedBottomLeft = Color.clear;
            _blendedBottomRight = Color.clear;
            _totalWeight = 0.0f;
        }

        public void Blend(VertexGradient startValue, VertexGradient endValue, float inputWeight, float progress)
        {
            _blendedTopLeft = Color.Lerp(startValue.topLeft, endValue.topLeft, progress) * inputWeight;
            _blendedTopRight = Color.Lerp(startValue.topRight, endValue.topRight, progress) * inputWeight;
            _blendedBottomLeft = Color.Lerp(startValue.bottomLeft, endValue.bottomLeft, progress) * inputWeight;
            _blendedBottomRight = Color.Lerp(startValue.bottomRight, endValue.bottomRight, progress) * inputWeight;
            _totalWeight += inputWeight;
        }

        public void ApplyFrame(TextMeshProUGUI binding)
        {
            if (_totalWeight == 0)
            {
                return;
            }

            _blendedTopLeft += binding.colorGradient.topLeft * (1f - _totalWeight);
            _blendedTopRight += binding.colorGradient.topRight * (1f - _totalWeight);
            _blendedBottomLeft += binding.colorGradient.bottomLeft * (1f - _totalWeight);
            _blendedBottomRight += binding.colorGradient.bottomRight * (1f - _totalWeight);
            binding.colorGradientPreset = null;
            binding.colorGradient =
                new VertexGradient(_blendedTopLeft, _blendedTopRight, _blendedBottomLeft, _blendedBottomRight);
        }
    }
}