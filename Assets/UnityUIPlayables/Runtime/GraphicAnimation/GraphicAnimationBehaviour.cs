using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class GraphicAnimationBehaviour : AnimationBehaviour
    {
        [SerializeField] private GraphicAnimationValue _startValue;
        [SerializeField] private GraphicAnimationValue _endValue;

        public GraphicAnimationValue StartValue => _startValue;
        public GraphicAnimationValue EndValue => _endValue;
    }
}