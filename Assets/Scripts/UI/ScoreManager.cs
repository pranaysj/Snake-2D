using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {  get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    private int snakeOne_Score = 0;
    private int snakeTwo_Score = 0;

    public TMP_Text snakeOne_ScoreText;
    public TMP_Text snakeTwo_ScoreText;

    public bool isSnakeOne_ScoreBA = false;
    public bool isSnakeTwo_ScoreBA = false;

    public bool scoreBoosterActive = false;

    public GameObject scoreTwoGameobject;

    private void Start()
    {
        if(Lobby.isSecondSnakeSpawn) scoreTwoGameobject.SetActive(true);
    }

    public void FoodType(FoodItemSO type, GameObject currentGameObject)
    {

        if (currentGameObject.CompareTag("FirstSnakeHead"))
        {

            if (isSnakeOne_ScoreBA)
            {
                snakeOne_Score += type.score * 2;
            }
            else
            {
                snakeOne_Score += type.score;

            }

            snakeOne_ScoreText.text = " Score : " + snakeOne_Score.ToString();

        }
        
        if (currentGameObject.CompareTag("SecondSnakeHead"))
        {
            if (isSnakeTwo_ScoreBA)
            {
                snakeTwo_Score += type.score * 2;
            }
            else
            {
                snakeTwo_Score += type.score;

            }

            snakeTwo_ScoreText.text = " Score : " + snakeTwo_Score.ToString();
        }
    }
}
