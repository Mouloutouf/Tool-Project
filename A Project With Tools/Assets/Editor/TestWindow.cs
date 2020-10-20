using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class TestWindow : EditorWindow
{
    LevelProfile currentProfile;

    [MenuItem("Window/TestWindow %&#w")]
    public static void Init()
    {
        TestWindow window = EditorWindow.GetWindow(typeof(TestWindow)) as TestWindow;

        // Initialize Window

        window.Show();
    }

    public static void InitWithContent(LevelProfile profile)
    {
        TestWindow window = EditorWindow.GetWindow(typeof(TestWindow)) as TestWindow;

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

        if (currentProfile.levelValues.Length > 0)
        {
            float tileWidth = 50f;
            float tileHeight = 50f;

            //int rowAmount = 2;
            //int columnAmount = 2;

            Event currentEvent = Event.current;

            for (int i = 0; i < currentProfile.levelValues.Length; i++)
            {
                Rect squareRect = new Rect(30 + tileWidth * i, 30 + tileHeight * i, tileWidth, tileHeight);

                EditorGUIUtility.AddCursorRect(squareRect, MouseCursor.Pan);

                if (squareRect.Contains(currentEvent.mousePosition))
                    EditorGUI.DrawRect(squareRect, Color.blue);
                else EditorGUI.DrawRect(squareRect, Color.red);
            }

            Repaint();
        }

        DisplayTest();
    }

    void DisplayTest()
    {
        //EditorGUI.DrawRect(new Rect(30, 30, 100, 100), Color.green);

        Rect pos = this.position;
        float w = pos.width;
        float h = pos.height;

        Rect closeButtonRect = new Rect(w*0.1f, h*0.2f, w*0.6f, h*0.3f);
        if (GUI.Button(closeButtonRect, "Export as JSON"))
        {
            string curveAsJSON = JsonUtility.ToJson(currentProfile, true);
            string filePath = "Assets/myCurve.json";
            File.WriteAllText(filePath, curveAsJSON);
        }
    }
}
