using UnityEngine;

namespace UnityUIPlayables
{
    public class RectTransformAnimationMixer : AnimationMixer<RectTransform, RectTransformAnimationBehaviour>
    {
        private readonly RectTransformPositionMixer _positionMixer = new RectTransformPositionMixer();
        private readonly RectTransformRotationMixer _rotationMixer = new RectTransformRotationMixer();
        private readonly RectTransformScaleMixer _scaleMixer = new RectTransformScaleMixer();
        private readonly RectTransformSizeDeltaMixer _sizeDeltaMixer = new RectTransformSizeDeltaMixer();

        public override void SetupFrame(RectTransform binding)
        {
            base.SetupFrame(binding);
            _positionMixer.SetupFrame();
            _sizeDeltaMixer.SetupFrame();
            _rotationMixer.SetupFrame();
            _scaleMixer.SetupFrame();
        }

        public override void Blend(RectTransformAnimationBehaviour behaviour, float inputWeight, float progress)
        {
            if (behaviour.ControlPosition)
            {
                _positionMixer.Blend(behaviour.StartValue.AnchoredPosition, behaviour.EndValue.AnchoredPosition,
                    inputWeight, progress);
            }

            if (behaviour.ControlSize)
            {
                _sizeDeltaMixer.Blend(behaviour.StartValue.SizeDelta, behaviour.EndValue.SizeDelta, inputWeight,
                    progress);
            }

            if (behaviour.ControlRotation)
            {
                _rotationMixer.Blend(behaviour.StartValue.LocalRotation, behaviour.EndValue.LocalRotation, inputWeight,
                    progress);
            }

            if (behaviour.ControlScale)
            {
                _scaleMixer.Blend(behaviour.StartValue.LocalScale, behaviour.EndValue.LocalScale, inputWeight,
                    progress);
            }
        }

        public override void ApplyFrame()
        {
            _positionMixer.ApplyFrame(Binding);
            _sizeDeltaMixer.ApplyFrame(Binding);
            _rotationMixer.ApplyFrame(Binding);
            _scaleMixer.ApplyFrame(Binding);
        }
    }
}