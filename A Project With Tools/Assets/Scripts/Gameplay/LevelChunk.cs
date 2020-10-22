using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Chunk", menuName = "Scriptable/Level Chunk")]
public class LevelChunk : ScriptableObject
{
    public Element[,] elements;

    public int rows;
    public int columns;

    public GameObject enemyPrefab;
    public GameObject wallPrefab;

    public Element[,] InitializeElements(int rows, int columns)
    {
        Element[,] _elements = new Element[rows, columns];

        for (int i = 0; i < _elements.GetLength(0); i++)
        {
            for (int u = 0; u < _elements.GetLength(1); u++)
            {
                _elements[i, u] = new Element { prefab = null, type = Elements.None, color = Color.white };
            }
        }

        return _elements;
    }

    [ContextMenu("Reset Elements list")]
    public void ResetElements()
    {
        elements = null;
        elements = InitializeElements(rows, columns);
    }
}
