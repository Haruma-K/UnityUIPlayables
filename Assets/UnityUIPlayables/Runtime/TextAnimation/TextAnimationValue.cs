using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class TextAnimationValue : GraphicAnimationValue
    {
        [SerializeField] private int _fontSize = 14;
        [SerializeField] private float _lineSpacing = 1.0f;

        public int FontSize => _fontSize;
        public float LineSpacing => _lineSpacing;
    }
}