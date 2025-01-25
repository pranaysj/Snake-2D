using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    public Sprite snake;
    public Sprite secondSnake;
    
    //For MVC
    public GameObject snake1Prefab;
    public GameObject second2Prefab;

    public GameObject snakeBodyPrefab;
    public GameObject secondSnakeBodyPrefab;

    public GameObject[] food;
    public GameObject[] powerUp;

    public Sprite GreenWin;
    public Sprite YellowWin;
    public Sprite Draw;
}
