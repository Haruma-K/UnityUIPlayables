using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class ImageAnimationBehaviour : AnimationBehaviour
    {
        [SerializeField] private ImageAnimationValue _startValue;
        [SerializeField] private ImageAnimationValue _endValue;

        public ImageAnimationValue StartValue => _startValue;
        public ImageAnimationValue EndValue => _endValue;
    }
}