using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class ImageAnimationValue : GraphicAnimationValue
    {
        [SerializeField] private float _fillAmount = 1.0f;

        public float FillAmount => _fillAmount;
    }
}