using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif

namespace UnityUIPlayables
{
    internal interface IAttributePropertyDrawer
    {
#if UNITY_EDITOR
        void OnGUI(Rect position, SerializedProperty property, GUIContent label);

        float GetPropertyHeight(SerializedProperty property, GUIContent label);
#endif
    }
}