namespace UnityUIPlayables
{
    public abstract class AnimationMixer<TBinding, TAnimationBehaviour>
    {
        protected TBinding Binding;

        public virtual void SetupFrame(TBinding binding)
        {
            Binding = binding;
        }

        public abstract void Blend(TAnimationBehaviour behaviour, float inputWeight, float progress);

        public abstract void ApplyFrame();
    }
}