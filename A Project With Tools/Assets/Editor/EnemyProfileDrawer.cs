using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EnemyProfile))]
public class EnemyProfileDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        // SerializedProperty colorProperty = property.FindPropertyRelative("color");
        // SerializedProperty redProperty = colorProperty.FindPropertyRelative("r");

        float lineAmount = 2f;
        if (EditorGUIUtility.currentViewWidth < 332) lineAmount++;
        //if (redProperty.floatValue > 0.5f) lineAmount++;
        return lineAmount * (EditorGUIUtility.singleLineHeight + 1);
    }

    public override void OnGUI(Rect rect, SerializedProperty property, GUIContent label)
    {
        Rect colorRect = new Rect(rect.x, rect.y, rect.width * 0.5f, rect.height);
        Rect speedrect = new Rect(rect.x + rect.width * 0.5f, rect.y, rect.width * 0.5f, rect.height);
        Rect vectorRect = new Rect(rect.x, rect.y + EditorGUIUtility.singleLineHeight + 1, rect.width, EditorGUIUtility.singleLineHeight);
        
        SerializedProperty colorProperty = property.FindPropertyRelative("color");
        SerializedProperty speedProperty = property.FindPropertyRelative("speed");
        SerializedProperty vectorProperty = property.FindPropertyRelative("spawnPosition");

        EditorGUI.PropertyField(colorRect, colorProperty, GUIContent.none);
        EditorGUI.PropertyField(speedrect, speedProperty, GUIContent.none);

        EditorGUI.PropertyField(vectorRect, vectorProperty, GUIContent.none);
    }
}
