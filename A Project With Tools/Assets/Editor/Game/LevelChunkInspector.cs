using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelChunk))]
public class LevelChunkInspector : Editor
{
    LevelChunk levelChunk;
    SerializedProperty myElements;

    SerializedProperty myEnemyPrefab;
    SerializedProperty myWallPrefab;
    
    private void OnEnable()
    {
        levelChunk = target as LevelChunk;

        myElements = serializedObject.FindProperty(nameof(levelChunk.elements));

        myEnemyPrefab = serializedObject.FindProperty(nameof(levelChunk.enemyPrefab));
        myWallPrefab = serializedObject.FindProperty(nameof(levelChunk.wallPrefab));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(myEnemyPrefab);
        EditorGUILayout.PropertyField(myWallPrefab);
        
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
        
        GUI.enabled = isElementList;
        if (GUILayout.Button("Open Editor"))
            LevelEditorWindow.InitWithContent(target as LevelChunk);
        GUI.enabled = true;
        
        serializedObject.ApplyModifiedProperties();
    }
}
