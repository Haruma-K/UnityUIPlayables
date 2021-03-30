using System;
using UnityEngine;
using UnityEngine.Playables;

namespace UnityUIPlayables
{
    [Serializable]
    public abstract class AnimationBehaviour : PlayableBehaviour
    {
        [SerializeField] private Curve _curve;

        public float EvaluateCurve(float progress)
        {
            return _curve.Evaluate(progress);
        }
    }
}