using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class SliderAnimationValue
    {
        [SerializeField] private float _value;

        public float Value => _value;
    }
}