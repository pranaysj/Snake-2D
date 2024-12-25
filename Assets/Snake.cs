using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    private void Awake()
    {
        GameObject snakehead = new GameObject("Snake", SpriteRenderer);
    }
}
