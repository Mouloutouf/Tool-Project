using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class LevelEditorWindow : EditorWindow
{
    LevelChunk currentProfile;

    [MenuItem("Window/Level Editor Window")]
    public static void Init()
    {
        LevelEditorWindow window = EditorWindow.GetWindow(typeof(LevelEditorWindow)) as LevelEditorWindow;

        // Initialize Window

        window.Show();
    }

    public static void InitWithContent(LevelChunk profile)
    {
        LevelEditorWindow window = EditorWindow.GetWindow(typeof(LevelEditorWindow)) as LevelEditorWindow;

        // Initialize Window
        window.currentProfile = profile;

        window.Show();
    }

    public void OnGUI()
    {
        if (currentProfile == null)
        {
            EditorGUILayout.LabelField("Currently displayed profile is null");
            return;
        }

        if (currentProfile.elements.Length > 0)
        {
            float tileWidth = 50f;
            float tileHeight = 50f;

            int rowAmount = currentProfile.elements.GetLength(0);
            int columnAmount = currentProfile.elements.GetLength(1);

            Event currentEvent = Event.current;

            float offset = 30f;
            float increment = 2f;

            for (int i = 0; i < rowAmount; i++)
            {
                for (int u = 0; u < columnAmount; u++)
                {
                    Rect squareRect = new Rect(offset + (increment * i) + (tileWidth * i), offset + (increment * u) + (tileHeight * u), tileWidth, tileHeight);

                    EditorGUIUtility.AddCursorRect(squareRect, MouseCursor.Arrow);

                    if (squareRect.Contains(currentEvent.mousePosition))
                        EditorGUI.DrawRect(squareRect, Color.grey);
                    else EditorGUI.DrawRect(squareRect, Color.white);

                    if (GUI.Button(squareRect, "yes")) currentProfile.elements[i, u] = new Element { prefab = null, type = Elements.Enemy };
                }
            }

            Repaint();
        }

        //DisplayTest();
    }

    void DisplayTest()
    {
        //EditorGUI.DrawRect(new Rect(30, 30, 100, 100), Color.green);

        Rect pos = this.position;
        float w = pos.width;
        float h = pos.height;

        Rect closeButtonRect = new Rect(w * 0.1f, h * 0.2f, w * 0.6f, h * 0.3f);
        if (GUI.Button(closeButtonRect, "Export as JSON"))
        {
            string curveAsJSON = JsonUtility.ToJson(currentProfile, true);
            string filePath = "Assets/myCurve.json";
            File.WriteAllText(filePath, curveAsJSON);
        }
    }
}
