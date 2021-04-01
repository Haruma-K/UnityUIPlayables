using System.Linq;
using UnityEditor;
using UnityEngine;

namespace UnityUIPlayables.Editor
{
    [CustomPropertyDrawer(typeof(MultiPropertyAttribute), true)]
    public class MultiPropertyAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var attributes = GetAttributes();
            var propertyDrawers = GetPropertyDrawers();

            if (attributes.Any(attr => !attr.IsVisible(property)))
            {
                return;
            }

            foreach (var attr in attributes)
            {
                attr.OnPreGUI(position, property);
            }

            using (var ccs = new EditorGUI.ChangeCheckScope())
            {
                if (propertyDrawers.Length == 0)
                {
                    EditorGUI.PropertyField(position, property, label, true);
                }
                else
                {
                    propertyDrawers.Last().OnGUI(position, property, label);
                }

                foreach (var attr in attributes.Reverse())
                {
                    attr.OnPostGUI(position, property, ccs.changed);
                }
            }
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var attributes = GetAttributes();
            var propertyDrawers = GetPropertyDrawers();

            if (attributes.Any(attr => !attr.IsVisible(property)))
            {
                return -EditorGUIUtility.standardVerticalSpacing;
            }

            var height = propertyDrawers.Length == 0
                ? EditorGUI.GetPropertyHeight(property, label, true)
                : propertyDrawers.Last().GetPropertyHeight(property, label);
            return height;
        }

        private MultiPropertyAttribute[] GetAttributes()
        {
            var attr = (MultiPropertyAttribute) attribute;

            if (attr.Attributes == null)
            {
                attr.Attributes = fieldInfo
                    .GetCustomAttributes(typeof(MultiPropertyAttribute), false)
                    .Cast<MultiPropertyAttribute>()
                    .OrderBy(x => x.order)
                    .ToArray();
            }

            return attr.Attributes;
        }

        private IAttributePropertyDrawer[] GetPropertyDrawers()
        {
            var attr = (MultiPropertyAttribute) attribute;

            if (attr.PropertyDrawers == null)
            {
                attr.PropertyDrawers = fieldInfo
                    .GetCustomAttributes(typeof(MultiPropertyAttribute), false)
                    .OfType<IAttributePropertyDrawer>()
                    .OrderBy(x => ((MultiPropertyAttribute) x).order)
                    .ToArray();
            }

            return attr.PropertyDrawers;
        }
    }
}