using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class LevelEditorWindow : EditorWindow
{
    LevelChunk currentChunk;

    Element currentElement = new Element { prefab = null, type = Elements.None, color = Color.white };

    Color hoverColor = Color.grey;

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
        window.currentChunk = profile;

        window.Show();
    }

    public void OnGUI()
    {
        if (currentChunk == null)
        {
            EditorGUILayout.LabelField("Currently displayed profile is null");
            return;
        }

        if (currentChunk.elements.Length > 0)
        {
            Buttons();

            DisplayLevelGrid();

            Repaint();
        }
    }
    
    void Buttons()
    {
        if (GUILayout.Button("Enemy")) currentElement = new Element { prefab = currentChunk.enemyPrefab, type = Elements.Enemy, color = Color.red };
        if (GUILayout.Button("Wall")) currentElement = new Element { prefab = currentChunk.wallPrefab, type = Elements.Wall, color = Color.yellow };
        if (GUILayout.Button("Erase")) currentElement = new Element { prefab = null, type = Elements.None, color = Color.white };
        
        EditorGUILayout.LabelField(currentElement.type.ToString());
    }

    void DisplayLevelGrid()
    {
        float tileWidth = 25f;
        float tileHeight = 25f;

        int rowAmount = currentChunk.elements.GetLength(0);
        int columnAmount = currentChunk.elements.GetLength(1);

        float extraOffset = 60f;
        float offset = 30f;
        float increment = 2f;

        Event currentEvent = Event.current;

        for (int i = 0; i < rowAmount; i++)
        {
            for (int u = 0; u < columnAmount; u++)
            {
                Rect squareRect = new Rect(offset + (increment * i) + (tileWidth * i), extraOffset + offset + (increment * u) + (tileHeight * u), tileWidth, tileHeight);

                EditorGUIUtility.AddCursorRect(squareRect, MouseCursor.Arrow);

                if (squareRect.Contains(currentEvent.mousePosition))
                {
                    EditorGUI.DrawRect(squareRect, hoverColor);

                    if (currentEvent.type == EventType.MouseDown)
                    {
                        currentChunk.elements[i, u] = currentElement;
                    }
                }
                else EditorGUI.DrawRect(squareRect, currentChunk.elements[i, u].color);
            }
        }
    }
}
