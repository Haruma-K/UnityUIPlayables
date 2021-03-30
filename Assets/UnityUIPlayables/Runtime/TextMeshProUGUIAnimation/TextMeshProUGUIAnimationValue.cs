using System;
using TMPro;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class TextMeshProUGUIAnimationValue
    {
        [SerializeField] private float _fontSize = 36;
        [SerializeField] private Color _color = Color.white;
        [SerializeField] private GradientValue _gradient;
        [SerializeField] private SpacingValue _spacing;
        [SerializeField] private Color _faceColor = Color.white;
        [SerializeField] private Color _outlineColor = Color.black;
        [SerializeField] private float _outlineWidth;

        public float FontSize => _fontSize;

        public Color Color => _color;

        public VertexGradient VertexGradient => _gradient.GetGradient();

        public SpacingValue Spacing => _spacing;

        public Color FaceColor => _faceColor;

        public Color OutlineColor => _outlineColor;

        public float OutlineWidth => _outlineWidth;

        [Serializable]
        private class GradientValue
        {
            [SerializeField] private bool _usePreset;

            [SerializeField] [EnabledIf(nameof(_usePreset), false)]
            private VertexGradient _vertexGradient = new VertexGradient(Color.white);

            [SerializeField] [EnabledIf(nameof(_usePreset), true)]
            private TMP_ColorGradient _preset;

            public VertexGradient GetGradient()
            {
                if (!_usePreset)
                {
                    return _vertexGradient;
                }

                if (_preset == null)
                {
                    return new VertexGradient(Color.white);
                }

                return new VertexGradient(_preset.topLeft, _preset.topRight, _preset.bottomLeft,
                    _preset.bottomRight);
            }
        }

        [Serializable]
        public struct SpacingValue
        {
            [SerializeField] private float _character;
            [SerializeField] private float _line;
            [SerializeField] private float _word;
            [SerializeField] private float _paragraph;

            public float Character => _character;

            public float Line => _line;

            public float Word => _word;

            public float Paragraph => _paragraph;
        }
    }
}