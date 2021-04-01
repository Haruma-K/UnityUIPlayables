using UnityEngine;

namespace UnityUIPlayables
{
    public class RectTransformPositionMixer
    {
        private Vector3 _blendedValue;
        private float _totalWeight;

        public void SetupFrame()
        {
            _blendedValue = Vector3.zero;
            _totalWeight = 0.0f;
        }

        public void Blend(Vector3 startValue, Vector3 endValue, float inputWeight, float progress)
        {
            _blendedValue += Vector3.Lerp(startValue, endValue, progress) * inputWeight;
            _totalWeight += inputWeight;
        }

        public void ApplyFrame(RectTransform binding)
        {
            if (_totalWeight == 0)
            {
                return;
            }

            _blendedValue += binding.anchoredPosition3D * (1f - _totalWeight);
            binding.anchoredPosition3D = _blendedValue;
        }
    }
}