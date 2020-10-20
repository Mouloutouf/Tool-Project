using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextConversion : MonoBehaviour
{
    public TextAsset textAsset;

    void Start()
    {
        string fileContent = textAsset.text;
        string[] lines = fileContent.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        List<string>[] table = new List<string>[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            table[i] = new List<string>();
            string[] columns = lines[i].Split(new string[] { "," }, StringSplitOptions.None);

            for (int y = 0; y < columns.Length; y++)
            {
                table[i].Add(columns[y]);
            }
        }
    }
}