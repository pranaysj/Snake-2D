using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    public static PowerUpManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    private Snake snake;
    private float defaultSpeed;
    
    private float delayTime = 5.0f;

    private bool isShieldActive = false;


    private void Start()
    {
        snake = GetComponent<Snake>();
        defaultSpeed = snake.move.SnakeSpeed;
    }

    public void PowerType(PowerUpSO type)
    {
        snake.move.SnakeSpeed = type.snakeSpeed;

        if (this.gameObject.CompareTag("FirstSnakeHead"))
        {
            ScoreManager.Instance.isSnakeOne_ScoreBA = type.isScoreBoosterActive;

        }
        if (this.gameObject.CompareTag("SecondSnakeHead"))
        {
            ScoreManager.Instance.isSnakeTwo_ScoreBA = type.isScoreBoosterActive;

        }

        //ScoreManager.Instance.scoreBoosterActive = type.isScoreBoosterActive;
        isShieldActive = type.isShieldActive;

        StartCoroutine(Delay(delayTime));
    }

    IEnumerator Delay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        snake.move.SnakeSpeed = defaultSpeed;
        ScoreManager.Instance.isSnakeOne_ScoreBA = false;
        ScoreManager.Instance.isSnakeTwo_ScoreBA = false;
        isShieldActive = false;
    }

    private void Update()
    {
        if (isShieldActive)
        {
            //Shield logic
        }
    }
}
