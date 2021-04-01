using UnityEngine.UI;

namespace UnityUIPlayables
{
    public class ImageAnimationMixer : AnimationMixer<Image, ImageAnimationBehaviour>
    {
        private readonly GraphicColorMixer _colorMixer = new GraphicColorMixer();
        private readonly ImageFillAmountMixer _fillAmountMixer = new ImageFillAmountMixer();

        public override void SetupFrame(Image binding)
        {
            base.SetupFrame(binding);
            _colorMixer.SetupFrame();
            _fillAmountMixer.SetupFrame();
        }

        public override void Blend(ImageAnimationBehaviour behaviour, float inputWeight, float progress)
        {
            if (behaviour.ControlColor)
            {
                _colorMixer.Blend(behaviour.StartValue.Color, behaviour.EndValue.Color, inputWeight, progress);
            }

            if (behaviour.ControlFillAmount)
            {
                _fillAmountMixer.Blend(behaviour.StartValue.FillAmount, behaviour.EndValue.FillAmount, inputWeight,
                    progress);
            }
        }

        public override void ApplyFrame()
        {
            _colorMixer.ApplyFrame(Binding);
            _fillAmountMixer.ApplyFrame(Binding);
        }
    }
}