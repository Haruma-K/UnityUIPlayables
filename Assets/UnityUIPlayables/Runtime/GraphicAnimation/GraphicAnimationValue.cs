using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class GraphicAnimationValue
    {
        [SerializeField] private Color _color = Color.white;

        public Color Color => _color;
    }
}