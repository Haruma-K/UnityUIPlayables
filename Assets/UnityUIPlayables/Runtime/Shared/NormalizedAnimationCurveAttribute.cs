using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace UnityUIPlayables
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    internal class NormalizedAnimationCurveAttribute : MultiPropertyAttribute
    {
        private readonly bool _normalizeTime;
        private readonly bool _normalizeValue;

        public NormalizedAnimationCurveAttribute(bool normalizeValue = true, bool normalizeTime = true)
        {
            _normalizeValue = normalizeValue;
            _normalizeTime = normalizeTime;
        }

#if UNITY_EDITOR
        public override void OnPostGUI(Rect position, SerializedProperty property, bool changed)
        {
            if (changed)
            {
                if (_normalizeValue)
                {
                    property.animationCurveValue = NormalizeValue(property.animationCurveValue);
                }

                if (_normalizeTime)
                {
                    property.animationCurveValue = NormalizeTime(property.animationCurveValue);
                }
            }
        }

        private static AnimationCurve NormalizeValue(AnimationCurve curve)
        {
            var keys = curve.keys;
            if (keys.Length <= 0)
            {
                return curve;
            }

            var minVal = keys[0].value;
            var maxVal = minVal;
            foreach (var t in keys)
            {
                minVal = Mathf.Min(minVal, t.value);
                maxVal = Mathf.Max(maxVal, t.value);
            }

            var range = maxVal - minVal;
            var valScale = range < 1 ? 1 : 1 / range;
            var valOffset = 0f;
            if (range < 1)
            {
                if (minVal > 0 && minVal + range <= 1)
                {
                    valOffset = minVal;
                }
                else
                {
                    valOffset = 1 - range;
                }
            }

            for (var i = 0; i < keys.Length; ++i)
            {
                keys[i].value = (keys[i].value - minVal) * valScale + valOffset;
            }

            curve.keys = keys;
            return curve;
        }

        private static AnimationCurve NormalizeTime(AnimationCurve curve)
        {
            var keys = curve.keys;
            if (keys.Length <= 0)
            {
                return curve;
            }

            var minTime = keys[0].time;
            var maxTime = minTime;
            foreach (var t in keys)
            {
                minTime = Mathf.Min(minTime, t.time);
                maxTime = Mathf.Max(maxTime, t.time);
            }

            var range = maxTime - minTime;
            var timeScale = range < 0.0001f ? 1 : 1 / range;
            for (var i = 0; i < keys.Length; ++i)
            {
                keys[i].time = (keys[i].time - minTime) * timeScale;
            }

            curve.keys = keys;
            return curve;
        }
#endif
    }
}