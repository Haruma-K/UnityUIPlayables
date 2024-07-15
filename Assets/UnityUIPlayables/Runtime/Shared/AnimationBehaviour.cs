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

        private readonly CurveEvaluateService _evaluateService = new();

        public float LoopDuration => _loopDuration;

        public LoopType LoopType => _loopType;

        public Curve Curve => _curve;

        public float EvaluateCurve(float time, float duration)
        {
            var loopDuration = _loopDuration > 0 ? _loopDuration : duration;
            return _loopType switch
            {
                LoopType.Repeat => _evaluateService.EvaluateRepeat(_curve, time, loopDuration),
                LoopType.Reverse => _evaluateService.EvaluateReverse(_curve, time, loopDuration),
                LoopType.PingPong => _evaluateService.EvaluatePingPong(_curve, time, loopDuration),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}