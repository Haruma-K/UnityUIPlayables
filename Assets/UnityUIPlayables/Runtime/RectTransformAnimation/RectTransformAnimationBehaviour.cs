using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class RectTransformAnimationBehaviour : AnimationBehaviour
    {
        [SerializeField] private bool _controlPosition;

        [SerializeField] private bool _controlSize;

        [SerializeField] private bool _controlRotation;

        [SerializeField] private bool _controlScale;

        [SerializeField] private RectTransformAnimationValue _startValue;

        [SerializeField] private RectTransformAnimationValue _endValue;

        public bool ControlPosition => _controlPosition;

        public bool ControlSize => _controlSize;

        public bool ControlRotation => _controlRotation;

        public bool ControlScale => _controlScale;

        public RectTransformAnimationValue StartValue => _startValue;
        public RectTransformAnimationValue EndValue => _endValue;
    }
}