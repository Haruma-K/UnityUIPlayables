using System;
using UnityEngine;
using UnityEngine.Assertions;

namespace UnityUIPlayables
{
    [Serializable]
    public class Curve
    {
        [SerializeField] private CurveType _curveType;

        [SerializeField] [EnabledIf(nameof(_curveType), (int) CurveType.Easing)]
        private EaseType _easeType;

        [NormalizedAnimationCurve(false)]
        [EnabledIf(nameof(_curveType), (int) CurveType.AnimationCurve)]
        [SerializeField]
        private AnimationCurve _animationCurve;

        public float Evaluate(float progress)
        {
            Assert.IsTrue(progress >= 0.0f);
            Assert.IsTrue(progress <= 1.0f);

            switch (_curveType)
            {
                case CurveType.Easing:
                    return Easings.Interpolate(progress, _easeType);
                case CurveType.AnimationCurve:
                    return _animationCurve.Evaluate(progress);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}