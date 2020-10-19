using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EnemyProfile))]
public class EnemyProfileDrawer : PropertyDrawer
{
    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        Rect colorRect = new Rect(rect.x, rect.y, rect.width * 0.5f, rect.height);
        Rect speedrect = new Rect(rect.x + rect.width * 0.5f, rect.y, rect.width * 0.5f, rect.height);
        
        SerializedProperty colorProperty = property.FindPropertyRelative("color");
        SerializedProperty speedProperty = property.FindPropertyRelative("speed");

        EditorGUI.PropertyField(colorRect, colorProperty, GUIContent.none);
        EditorGUI.PropertyField(speedrect, speedProperty, GUIContent.none);
    }
}
