using UnityEngine;
using UnityEngine.UI;

namespace UnityUIPlayables
{
    public class RawImageUVRectMixer
    {
        private Vector2 _blendedPosition;
        private Vector2 _blendedSize;
        private float _totalWeight;

        public void SetupFrame()
        {
            _blendedPosition = Vector2.zero;
            _blendedSize = Vector2.zero;
            _totalWeight = 0.0f;
        }

        public void Blend(Rect startValue, Rect endValue, float inputWeight, float progress)
        {
            _blendedPosition = Vector2.Lerp(startValue.position, endValue.position, progress) * inputWeight;
            _blendedSize = Vector2.Lerp(startValue.size, endValue.size, progress) * inputWeight;
            _totalWeight += inputWeight;
        }

        public void ApplyFrame(RawImage binding)
        {
            if (_totalWeight == 0)
            {
                return;
            }

            _blendedPosition += binding.uvRect.position * (1f - _totalWeight);
            _blendedSize += binding.uvRect.size * (1f - _totalWeight);
            binding.uvRect = new Rect(_blendedPosition, _blendedSize);
        }
    }
}