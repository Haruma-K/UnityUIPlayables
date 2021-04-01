using UnityEngine.UI;

namespace UnityUIPlayables
{
    public class TextAnimationMixer : AnimationMixer<Text, TextAnimationBehaviour>
    {
        private readonly GraphicColorMixer _colorMixer = new GraphicColorMixer();
        private readonly TextFontSizeMixer _fontSizeMixer = new TextFontSizeMixer();
        private readonly TextLineSpacingMixer _lineSpacingMixer = new TextLineSpacingMixer();

        public override void SetupFrame(Text binding)
        {
            base.SetupFrame(binding);
            _colorMixer.SetupFrame();
            _fontSizeMixer.SetupFrame();
            _lineSpacingMixer.SetupFrame();
        }

        public override void Blend(TextAnimationBehaviour behaviour, float inputWeight, float progress)
        {
            if (behaviour.ControlColor)
            {
                _colorMixer.Blend(behaviour.StartValue.Color, behaviour.EndValue.Color, inputWeight, progress);
            }

            if (behaviour.ControlFontSize)
            {
                _fontSizeMixer.Blend(behaviour.StartValue.FontSize, behaviour.EndValue.FontSize, inputWeight, progress);
            }

            if (behaviour.ControlLineSpacing)
            {
                _lineSpacingMixer.Blend(behaviour.StartValue.LineSpacing, behaviour.EndValue.LineSpacing, inputWeight,
                    progress);
            }
        }

        public override void ApplyFrame()
        {
            _colorMixer.ApplyFrame(Binding);
            _fontSizeMixer.ApplyFrame(Binding);
            _lineSpacingMixer.ApplyFrame(Binding);
        }
    }
}