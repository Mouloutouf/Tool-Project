using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelChunk))]
public class LevelChunkInspector : Editor
{
    LevelChunk levelChunk;
    SerializedProperty myElements;

    private void OnEnable()
    {
        levelChunk = target as LevelChunk;

        myElements = serializedObject.FindProperty(nameof(levelChunk.elements));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.BeginHorizontal();
        levelChunk.rows = EditorGUILayout.IntField(levelChunk.rows);
        levelChunk.columns = EditorGUILayout.IntField(levelChunk.columns);
        EditorGUILayout.EndHorizontal();

        bool isElementList = levelChunk.elements == null ? false : true;
        GUI.enabled = levelChunk.rows > 0 ? true : false;
        GUI.enabled = levelChunk.columns > 0 ? true : false;
        if (GUILayout.Button("Create Elements"))
        {
            levelChunk.elements = levelChunk.InitializeElements(levelChunk.rows, levelChunk.columns);
            isElementList = true;
        }
        GUI.enabled = true;

        //EditorGUILayout.BeginHorizontal();
        //myElements.arraySize = EditorGUILayout.IntField()

        //if (GUILayout.Button("Add Column")) myElements.arraySize++;
        //if (GUILayout.Button("Add Row") && myElements.arraySize > 0) myStrings.arraySize--;
        //EditorGUILayout.EndHorizontal();
        //EditorGUILayout.BeginHorizontal();
        //if (GUILayout.Button("Remove Row")) myElements.arraySize++;
        //if (GUILayout.Button("Remove Column") && myElements.arraySize > 0) myStrings.arraySize--;
        //EditorGUILayout.EndHorizontal();
        //if (myStrings.arraySize > 0)
        //{
        //    for (int i = 0; i < myStrings.arraySize; i++)
        //    {
        //        EditorGUILayout.PropertyField(myStrings.GetArrayElementAtIndex(i), new GUIContent("Text Field", "This is a really nice tool tip"));
        //    }
        //}

        GUI.enabled = isElementList;
        if (GUILayout.Button("Open Editor"))
            LevelEditorWindow.InitWithContent(target as LevelChunk);
        GUI.enabled = true;

        serializedObject.ApplyModifiedProperties();
    }
}
