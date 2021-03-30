using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace UnityUIPlayables
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    internal class EnabledIfAttribute : MultiPropertyAttribute
    {
        public enum HideMode
        {
            Invisible,
            Disabled
        }

        private readonly int _enableIfValueIs;
        private readonly HideMode _hideMode;
        private readonly string _switcherFieldName;

        public EnabledIfAttribute(string switcherFieldName, bool enableIfValueIs, HideMode hideMode = HideMode.Disabled)
            : this(switcherFieldName, enableIfValueIs ? 1 : 0, hideMode)
        {
        }

        public EnabledIfAttribute(string switcherFieldName, int enableIfValueIs, HideMode hideMode = HideMode.Disabled)
        {
            _hideMode = hideMode;
            _switcherFieldName = switcherFieldName;
            _enableIfValueIs = enableIfValueIs;
        }

#if UNITY_EDITOR
        public override void OnPreGUI(Rect position, SerializedProperty property)
        {
            var isEnabled = GetIsEnabled(property);

            if (_hideMode == HideMode.Disabled)
            {
                GUI.enabled &= isEnabled;
            }
        }

        public override void OnPostGUI(Rect position, SerializedProperty property, bool changed)
        {
            if (_hideMode == HideMode.Disabled)
            {
                GUI.enabled = true;
            }
        }

        public override bool IsVisible(SerializedProperty property)
        {
            return _hideMode != HideMode.Invisible || GetIsEnabled(property);
        }

        private bool GetIsEnabled(SerializedProperty property)
        {
            return _enableIfValueIs == GetSwitcherPropertyValue(property);
        }

        private int GetSwitcherPropertyValue(SerializedProperty property)
        {
            var propertyNameIndex = property.propertyPath.LastIndexOf(property.name, StringComparison.Ordinal);
            var switcherPropertyName = property.propertyPath.Substring(0, propertyNameIndex) + _switcherFieldName;
            var switcherProperty = property.serializedObject.FindProperty(switcherPropertyName);
            switch (switcherProperty.propertyType)
            {
                case SerializedPropertyType.Boolean:
                    return switcherProperty.boolValue ? 1 : 0;
                case SerializedPropertyType.Enum:
                    return switcherProperty.intValue;
                default:
                    throw new Exception("unsupported type.");
            }
        }
#endif
    }
}