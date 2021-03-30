using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class TextMeshProUGUIAnimationBehaviour : AnimationBehaviour
    {
        [SerializeField] private bool _controlFontSize;
        [SerializeField] private bool _controlColor;
        [SerializeField] private bool _controlVertexGradient;
        [SerializeField] private bool _controlSpacing;
        [SerializeField] private bool _controlFaceColor;
        [SerializeField] private bool _controlOutlineColor;
        [SerializeField] private bool _controlOutlineWidth;
        [SerializeField] private TextMeshProUGUIAnimationValue _startValue;
        [SerializeField] private TextMeshProUGUIAnimationValue _endValue;

        public bool ControlFontSize => _controlFontSize;

        public bool ControlColor => _controlColor;

        public bool ControlVertexGradient => _controlVertexGradient;

        public bool ControlSpacing => _controlSpacing;

        public bool ControlFaceColor => _controlFaceColor;

        public bool ControlOutlineColor => _controlOutlineColor;

        public bool ControlOutlineWidth => _controlOutlineWidth;
        public TextMeshProUGUIAnimationValue StartValue => _startValue;
        public TextMeshProUGUIAnimationValue EndValue => _endValue;
    }
}