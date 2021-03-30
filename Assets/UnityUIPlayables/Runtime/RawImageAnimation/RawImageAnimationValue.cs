using System;
using UnityEngine;

namespace UnityUIPlayables
{
    [Serializable]
    public class RawImageAnimationValue : GraphicAnimationValue
    {
        [SerializeField] private Rect _uvRect = new Rect(0, 0, 1, 1);

        public Rect UvRect => _uvRect;
    }
}