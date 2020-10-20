using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CubeBehaviour))]
public class CubeBehaviourEditor : Editor
{
    CubeBehaviour cubeBehaviour;
    Transform cubeTransform;

    private void OnEnable()
    {
        cubeBehaviour = target as CubeBehaviour;
        cubeTransform = (cubeBehaviour).transform;
    }

    private void OnDisable()
    {
        
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    public void OnSceneGUI()
    {
        Handles.BeginGUI();
        EditorGUILayout.LabelField("This is a display in the scene");
        Handles.EndGUI();

        //SphereMoveDisplay();

        //CircleRotateDisplay();

        //cubeTransform.position = Handles.FreeMoveHandle(pos, rot, size, snap, Handles.CubeHandleCap);

        EditorUtility.SetDirty(cubeTransform);
        EditorUtility.SetDirty(cubeBehaviour);
    }

    void SphereMoveDisplay()
    {
        Vector3 pos = cubeTransform.position;
        Quaternion rot = cubeTransform.rotation;
        float size = 1f;
        Vector3 snap = Vector3.zero;

        for (int i = 0; i < cubeBehaviour.outputVector.Length; i++)
        {
            Handles.color = Color.white;

            Handles.DrawLine(pos + cubeBehaviour.outputVector[i], pos + cubeBehaviour.outputVector[(i + 1) % cubeBehaviour.outputVector.Length]);

            Handles.color = i % 2 == 0 ? Color.grey : Color.cyan;

            cubeBehaviour.outputVector[i] = Handles.FreeMoveHandle(
                pos + cubeBehaviour.outputVector[i],
                rot,
                size * HandleUtility.GetHandleSize(pos + cubeBehaviour.outputVector[i]),
                snap,
                Handles.SphereHandleCap
                ) - pos;
        }
    }

    void CircleRotateDisplay()
    {
        Vector3 pos = cubeTransform.position;
        float size = 1f;

        for (int i = 0; i < cubeBehaviour.outputQuaternion.Length; i++)
        {
            Handles.color = i % 2 == 0 ? Color.grey : Color.cyan;

            cubeBehaviour.outputQuaternion[i] = Handles.FreeRotateHandle(
                cubeBehaviour.outputQuaternion[i],
                pos + cubeBehaviour.outputVector[i],
                size * HandleUtility.GetHandleSize(pos + cubeBehaviour.outputVector[i])
                );
        }
    }
}
