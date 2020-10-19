using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
[CanEditMultipleObjects] // Used to select multiple objects and edit their same component variables
public class GameManagerInspector : Editor
{
    GameManager manager;

    public void OnEnable()
    {
        manager = target as GameManager;

        Undo.undoRedoPerformed += AfterUndo;
    }

    public void AfterUndo() {}

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical();

        manager.myColor = EditorGUILayout.ColorField("My Color", manager.myColor);
        manager.myTransform = EditorGUILayout.ObjectField("My Transform", manager.myTransform, typeof(Transform), true) as Transform;

        #region Buttons

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Auto Set References"))
        {
            AutoSetReferences();
        }
        if (GUILayout.Button("Auto Clear References"))
        {
            AutoClearReferences();
        }
        GUILayout.EndHorizontal();

        GUILayout.EndVertical();

        #endregion

        manager.foldoutState = EditorGUILayout.Foldout(manager.foldoutState, "Fold Here", true);
        if (manager.foldoutState)
        {
            EditorGUILayout.LabelField("Hello guys");
        }
    }

    void AutoSetReferences()
    {
        Undo.RecordObject(manager, "Set references");

        manager.audioListener = Object.FindObjectOfType<AudioListener>();
        manager.camera = Object.FindObjectOfType<Camera>();
        manager.myTransform = manager.transform;
        manager.camTransform = manager.camera.transform;
    }

    void AutoClearReferences()
    {
        Undo.RecordObject(manager, "Clear references");

        manager.audioListener = null;
        manager.camera = null;
        manager.myTransform = null;
        manager.camTransform = null;
    }

    public void OnDisable()
    {
        Undo.undoRedoPerformed -= AfterUndo;
    }
}
