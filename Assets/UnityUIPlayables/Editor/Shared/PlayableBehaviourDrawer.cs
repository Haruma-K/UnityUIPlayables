using UnityEditor;
using UnityEngine;

namespace UnityUIPlayables.Editor
{
    public class PlayableBehaviourDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.indentLevel--;

            // Draw default GUI without property name.
            property = property.serializedObject.FindProperty(property.propertyPath);
            var fieldRect = position;
            fieldRect.height = EditorGUIUtility.singleLineHeight;

            using (new EditorGUI.PropertyScope(fieldRect, label, property))
            {
                using (new EditorGUI.IndentLevelScope())
                {
                    property.NextVisible(true);
                    var depth = property.depth;
                    EditorGUI.PropertyField(fieldRect, property, true);
                    fieldRect.y += EditorGUI.GetPropertyHeight(property, true);
                    fieldRect.y += EditorGUIUtility.standardVerticalSpacing;

                    while (property.NextVisible(false))
                    {
                        if (property.depth != depth)
                        {
                            break;
                        }

                        EditorGUI.PropertyField(fieldRect, property, true);
                        fieldRect.y += EditorGUI.GetPropertyHeight(property, true);
                        fieldRect.y += EditorGUIUtility.standardVerticalSpacing;
                    }
                }
            }

            EditorGUI.indentLevel++;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            property = property.serializedObject.FindProperty(property.propertyPath);
            var height = 0.0f;

            property.NextVisible(true);
            var depth = property.depth;
            height += EditorGUI.GetPropertyHeight(property, true);
            height += EditorGUIUtility.standardVerticalSpacing;

            while (property.NextVisible(false))
            {
                if (property.depth != depth)
                {
                    break;
                }

                height += EditorGUI.GetPropertyHeight(property, true);
                height += EditorGUIUtility.standardVerticalSpacing;
            }

            height -= EditorGUIUtility.standardVerticalSpacing;

            return height;
        }
    }
}