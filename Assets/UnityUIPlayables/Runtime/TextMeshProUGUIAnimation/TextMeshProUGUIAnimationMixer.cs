using TMPro;

namespace UnityUIPlayables
{
    public class TextMeshProUGUIAnimationMixer : AnimationMixer<TextMeshProUGUI, TextMeshProUGUIAnimationBehaviour>
    {
        private readonly TextMeshProUGUIColorMixer _colorMixer = new TextMeshProUGUIColorMixer();
        private readonly TextMeshProUGUIFaceColorMixer _faceColorMixer = new TextMeshProUGUIFaceColorMixer();
        private readonly TextMeshProUGUIFontSizeMixer _fontSizeMixer = new TextMeshProUGUIFontSizeMixer();
        private readonly TextMeshProUGUIOutlineColorMixer _outlineColorMixer = new TextMeshProUGUIOutlineColorMixer();
        private readonly TextMeshProUGUIOutlineWidthMixer _outlineWidthMixer = new TextMeshProUGUIOutlineWidthMixer();

        private readonly TextMeshProUGUISpacingMixer _spacingMixer = new TextMeshProUGUISpacingMixer();

        private readonly TextMeshProUGUIVertexGradientMixer _vertexGradientMixer =
            new TextMeshProUGUIVertexGradientMixer();


        public override void SetupFrame(TextMeshProUGUI binding)
        {
            base.SetupFrame(binding);
            _fontSizeMixer.SetupFrame();
            _colorMixer.SetupFrame();
            _vertexGradientMixer.SetupFrame();
            _spacingMixer.SetupFrame();
            _faceColorMixer.SetupFrame();
            _outlineColorMixer.SetupFrame();
            _outlineWidthMixer.SetupFrame();
        }

        public override void Blend(TextMeshProUGUIAnimationBehaviour behaviour, float inputWeight, float progress)
        {
            if (behaviour.ControlFontSize)
            {
                _fontSizeMixer.Blend(behaviour.StartValue.FontSize, behaviour.EndValue.FontSize, inputWeight, progress);
            }

            if (behaviour.ControlColor)
            {
                _colorMixer.Blend(behaviour.StartValue.Color, behaviour.EndValue.Color, inputWeight, progress);
            }

            if (behaviour.ControlVertexGradient)
            {
                _vertexGradientMixer.Blend(behaviour.StartValue.VertexGradient, behaviour.EndValue.VertexGradient,
                    inputWeight, progress);
            }

            if (behaviour.ControlSpacing)
            {
                _spacingMixer.Blend(behaviour.StartValue.Spacing, behaviour.EndValue.Spacing, inputWeight, progress);
            }

            if (behaviour.ControlRuntimeFaceColor)
            {
                _faceColorMixer.Blend(behaviour.StartValue.FaceColor, behaviour.EndValue.FaceColor, inputWeight,
                    progress);
            }

            if (behaviour.ControlRuntimeOutlineColor)
            {
                _outlineColorMixer.Blend(behaviour.StartValue.OutlineColor, behaviour.EndValue.OutlineColor,
                    inputWeight, progress);
            }

            if (behaviour.ControlRuntimeOutlineWidth)
            {
                _outlineWidthMixer.Blend(behaviour.StartValue.OutlineWidth, behaviour.EndValue.OutlineWidth,
                    inputWeight, progress);
            }
        }

        public override void ApplyFrame()
        {
            _fontSizeMixer.ApplyFrame(Binding);
            _colorMixer.ApplyFrame(Binding);
            _vertexGradientMixer.ApplyFrame(Binding);
            _spacingMixer.ApplyFrame(Binding);
            _faceColorMixer.ApplyFrame(Binding);
            _outlineColorMixer.ApplyFrame(Binding);
            _outlineWidthMixer.ApplyFrame(Binding);
        }
    }
}