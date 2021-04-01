using UnityEngine;

namespace UnityUIPlayables
{
    public class RectTransformSizeDeltaMixer
    {
        private Vector2 _blendedValue;
        private float _totalWeight;

        public void SetupFrame()
        {
            _blendedValue = Vector2.zero;
            _totalWeight = 0.0f;
        }

        public void Blend(Vector2 startValue, Vector2 endValue, float inputWeight, float progress)
        {
            _blendedValue += Vector2.Lerp(startValue, endValue, progress) * inputWeight;
            _totalWeight += inputWeight;
        }

        public void ApplyFrame(RectTransform binding)
        {
            if (_totalWeight == 0)
            {
                return;
            }

            _blendedValue += binding.sizeDelta * (1f - _totalWeight);
            binding.sizeDelta = _blendedValue;
        }
    }
}