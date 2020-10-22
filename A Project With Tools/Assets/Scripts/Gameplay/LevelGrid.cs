﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Elements { Wall, Enemy, Coin, None }

[System.Serializable]
public class Element
{
    public GameObject prefab;
    public Elements type;
    public Color color;
}

public class LevelGrid : MonoBehaviour
{
    public int rows;
    public int columns;

    public float tileSize;

    private Vector2[,] positions;

    public List<LevelChunk> chunks;

    private void Start()
    {
        CreateGrid();

        //SpawnElements(chunks[0]); // Default
    }

    void CreateGrid()
    {
        positions = new Vector2[rows, columns];

        for (int i = 0; i < positions.GetLength(0); i++)
        {
            for (int u = 0; u < positions.GetLength(1); u++)
            {
                positions[i,u] = new Vector2((tileSize / 2f) + tileSize * i, (tileSize / 2f) + tileSize * u);
            }
        }
    }

    void SpawnElements(LevelChunk chunk)
    {
        Element[,] elements = chunk.elements;

        for (int v = 0; v < elements.GetLength(0); v++)
        {
            for (int w = 0; w < elements.GetLength(1); w++)
            {
                Element spawned = elements[v,w];

                Instantiate(spawned.prefab, positions[v,w], Quaternion.identity);
            }
        }
    }
}
