using UnityEngine.Playables;

namespace UnityUIPlayables
{
    public class AnimationMixerBehaviour<TBinding, TValueMixer, TAnimationBehaviour> : PlayableBehaviour
        where TValueMixer : AnimationMixer<TBinding, TAnimationBehaviour>, new()
        where TBinding : class
        where TAnimationBehaviour : AnimationBehaviour, new()
    {
        private TValueMixer _mixer = new TValueMixer();

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (!(playerData is TBinding binding))
            {
                return;
            }

            var inputCount = playable.GetInputCount();

            var mixer = new TValueMixer();
            mixer.SetupFrame(binding);

            for (var i = 0; i < inputCount; i++)
            {
                var playableInput = (ScriptPlayable<TAnimationBehaviour>) playable.GetInput(i);
                var behaviour = playableInput.GetBehaviour();

                var inputWeight = playable.GetInputWeight(i);
                var time = (float) playableInput.GetTime();
                var duration = (float) playableInput.GetDuration();
                var progress = behaviour.EvaluateCurve(time, duration);

                if (inputWeight == 0)
                {
                    continue;
                }

                mixer.Blend(behaviour, inputWeight, progress);
            }

            mixer.ApplyFrame();
        }
    }
}