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
        [SerializeField] private bool _controlRuntimeFaceColor;
        [SerializeField] private bool _controlRuntimeOutlineColor;
        [SerializeField] private bool _controlRuntimeOutlineWidth;
        [SerializeField] private TextMeshProUGUIAnimationValue _startValue;
        [SerializeField] private TextMeshProUGUIAnimationValue _endValue;

        public bool ControlFontSize => _controlFontSize;

        public bool ControlColor => _controlColor;

        public bool ControlVertexGradient => _controlVertexGradient;

        public bool ControlSpacing => _controlSpacing;

        public bool ControlRuntimeFaceColor => _controlRuntimeFaceColor;

        public bool ControlRuntimeOutlineColor => _controlRuntimeOutlineColor;

        public bool ControlRuntimeOutlineWidth => _controlRuntimeOutlineWidth;
        public TextMeshProUGUIAnimationValue StartValue => _startValue;
        public TextMeshProUGUIAnimationValue EndValue => _endValue;
    }
}