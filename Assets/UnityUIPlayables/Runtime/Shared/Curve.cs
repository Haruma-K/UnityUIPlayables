using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    internal class Curve
    {
        [SerializeField] private CurveType _curveType;
        
        [SerializeField]
        [EnabledIf(nameof(_curveType), (int)CurveType.Easing)]
        private EaseType _easeType;
        
        [NormalizedAnimationCurve(false)]
        [EnabledIf(nameof(_curveType), (int)CurveType.AnimationCurve)]
        [SerializeField] private AnimationCurve _animationCurve;

        public float Evaluate(float progress)
        {
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
