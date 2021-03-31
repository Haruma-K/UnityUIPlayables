using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class ImageAnimationBehaviour : AnimationBehaviour
    {
        [SerializeField] private bool _controlColor;
        [SerializeField] private bool _controlFillAmount;
        [SerializeField] private ImageAnimationValue _startValue;
        [SerializeField] private ImageAnimationValue _endValue;

        public bool ControlColor => _controlColor;

        public bool ControlFillAmount => _controlFillAmount;

        public ImageAnimationValue StartValue => _startValue;
        public ImageAnimationValue EndValue => _endValue;
    }
}