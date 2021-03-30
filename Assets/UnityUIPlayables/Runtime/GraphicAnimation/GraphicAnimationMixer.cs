using UnityEngine.UI;

namespace UnityUIPlayables
{
    public class GraphicAnimationMixer : AnimationMixer<Graphic, GraphicAnimationBehaviour>
    {
        private readonly GraphicColorMixer _colorMixer = new GraphicColorMixer();

        public override void SetupFrame(Graphic binding)
        {
            base.SetupFrame(binding);
            _colorMixer.SetupFrame();
        }

        public override void Blend(GraphicAnimationBehaviour behaviour, float inputWeight, float progress)
        {
            // Color
            _colorMixer.Blend(behaviour.StartValue.Color, behaviour.EndValue.Color, inputWeight, progress);
        }

        public override void ApplyFrame()
        {
            _colorMixer.ApplyFrame(Binding);
        }
    }
}