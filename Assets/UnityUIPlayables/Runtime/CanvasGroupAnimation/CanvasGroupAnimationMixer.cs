using UnityEngine;
using UnityEngine.UI;

namespace UnityUIPlayables
{
    public class CanvasGroupAnimationMixer : AnimationMixer<CanvasGroup, CanvasGroupAnimationBehaviour>
    {
        private readonly CanvasGroupAlphaMixer _alphaMixer = new CanvasGroupAlphaMixer();
        
        public override void SetupFrame(CanvasGroup binding)
        {
            base.SetupFrame(binding);
            _alphaMixer.SetupFrame();
        }

        public override void Blend(CanvasGroupAnimationBehaviour behaviour, float inputWeight, float progress)
        {
            _alphaMixer.Blend(behaviour.StartValue.Alpha, behaviour.EndValue.Alpha, inputWeight, progress);
        }

        public override void ApplyFrame()
        {
            _alphaMixer.ApplyFrame(Binding);
        }
    }
}