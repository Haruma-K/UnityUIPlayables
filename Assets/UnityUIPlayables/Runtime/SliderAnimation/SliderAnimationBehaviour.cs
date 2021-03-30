using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class SliderAnimationBehaviour : AnimationBehaviour
    {
        [SerializeField] private SliderAnimationValue _startValue;
        [SerializeField] private SliderAnimationValue _endValue;

        public SliderAnimationValue StartValue => _startValue;
        public SliderAnimationValue EndValue => _endValue;
    }
}