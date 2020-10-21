using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Elements { Wall, Enemy, Coin, None }

[System.Serializable]
public class Element
{
    public GameObject prefab;
    public Elements type;
}

public class LevelGrid : MonoBehaviour
{
    public int rows;
    public int columns;

    public int tileSize;

    private Vector2[][] positions;

    public List<LevelChunk> chunks;

    private void Start()
    {
        CreateGrid();

        SpawnElements(chunks[0]); // Default
    }

    void CreateGrid()
    {
        positions = new Vector2[(rows / tileSize)][];

        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = new Vector2[(columns / tileSize)];

            for (int u = 0; u < positions[i].Length; u++)
            {
                positions[i][u] = new Vector2((tileSize / 2) + i, (tileSize / 2) + u);
            }
        }
    }

    void SpawnElements(LevelChunk chunk)
    {
        Element[][] elements = chunk.elements;

        for (int v = 0; v < elements.Length; v++)
        {
            for (int w = 0; w < elements[v].Length; w++)
            {
                Element spawned = elements[v][w];

                Instantiate(spawned.prefab, positions[v][w], Quaternion.identity);
            }
        }
    }
}
