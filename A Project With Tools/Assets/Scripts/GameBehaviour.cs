using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public Color myColor;
    [Header("Texts")]
    public string myString;
    [TextArea]
    public string myBigString;
    [Header("Numbers")]
    [Range(0f, 1f)]
    public float mySlider;
    public Vector2 myVector2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
