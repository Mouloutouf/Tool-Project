using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Chunk", menuName = "Scriptable/Level Chunk")]
public class LevelChunk : ScriptableObject
{
    public Element[][] elements;
}
