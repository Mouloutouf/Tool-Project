using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class TSVFormatProcessor : AssetPostprocessor
{
    public void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetsPath)
    {
        if (importedAssets == null) return;
        if (importedAssets.Length == 0) return;
        for (int i = 0; i < importedAssets.Length; i++)
        {
            // Ensure file is a TSV
            string str = importedAssets[i];
            if (!str.EndsWith(".tsv")) continue;

            // If so, change extension, don't forget metafiles
            str = str.Substring(0, str.Length-4);
            str += ".csv";
            File.Move(importedAssets[i], str);
            File.Move(importedAssets[i]+".meta", str+".meta");

            // Switch all tabulations to a wanted separator (here a semicolon)
            char separator = ';';
            string content = File.ReadAllText(str);
            content = content.Replace('\t', separator);
            File.WriteAllText(str, content);
        }
    }

    void ConvertToCSV(string assetPath)
    {
        AssetDatabase.RenameAsset(assetPath, assetPath.Replace(".tsv", ".csv"));
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}
