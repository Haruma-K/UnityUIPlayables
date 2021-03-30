using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class CanvasGroupAnimationBehaviour : AnimationBehaviour
    {
        [SerializeField] private CanvasGroupAnimationValue _startValue;
        [SerializeField] private CanvasGroupAnimationValue _endValue;

        public CanvasGroupAnimationValue StartValue => _startValue;
        public CanvasGroupAnimationValue EndValue => _endValue;
    }
}