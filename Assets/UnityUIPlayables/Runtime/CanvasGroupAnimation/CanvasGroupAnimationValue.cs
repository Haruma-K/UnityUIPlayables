using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class CanvasGroupAnimationValue
    {
        [SerializeField] private float _alpha = 1.0f;

        public float Alpha => _alpha;
    }
}