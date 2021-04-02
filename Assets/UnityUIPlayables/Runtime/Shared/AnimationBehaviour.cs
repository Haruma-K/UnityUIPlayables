using System;
using UnityEngine;
using UnityEngine.Playables;

namespace UnityUIPlayables
{
    [Serializable]
    public abstract class AnimationBehaviour : PlayableBehaviour
    {
        [SerializeField] [Tooltip("When set to zero, the length of one loop equals the length of the clip.")]
        private float _loopDuration;

        [SerializeField] private LoopType _loopType;
        [SerializeField] private Curve _curve;

        public float LoopDuration => _loopDuration;

        public LoopType LoopType => _loopType;

        public Curve Curve => _curve;

        public float EvaluateCurve(float time, float duration)
        {
            var loopDuration = _loopDuration > 0 ? _loopDuration : duration;
            var progress = time / loopDuration;
            var ret = Mathf.Floor(progress) % 2 != 0;
            switch (_loopType)
            {
                case LoopType.Repeat:
                    progress = Mathf.Repeat(progress, 1.0f);
                    break;
                case LoopType.Reverse:
                    progress = Mathf.Repeat(progress, 1.0f);
                    break;
                case LoopType.PingPong:
                    progress = Mathf.PingPong(progress, 1.0f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            progress = _curve.Evaluate(progress);
            
            if (_loopType == LoopType.Reverse & ret)
            {
                progress = 1 - progress;
            }

            return progress;
        }
    }
}