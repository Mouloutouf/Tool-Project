using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameBehaviour))]
public class GameBehaviourInspector : Editor
{
    GameBehaviour behaviour;
    SerializedProperty myColorProperty;

    public void OnEnable()
    {
        behaviour = target as GameBehaviour;

        myColorProperty = serializedObject.FindProperty(nameof(behaviour.myColor));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
    
        // Stuff

        if (GUILayout.Button("Turn Red")) myColorProperty.colorValue = Color.red;
        if (GUILayout.Button("Turn Green")) myColorProperty.colorValue = Color.green;
        EditorGUILayout.PropertyField(myColorProperty);

        serializedObject.ApplyModifiedProperties();
    }
}
