using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }

        Instance = this;
    }

    public GameObject gameOverPanel;
    public Image gameOverImage;


    public void VictoryCondition(GameObject snake)
    {

        //Check fro segemnt attach to head (Game Over)
        if (snake.CompareTag("FirstSnakeHead"))
        {
            //Yellow win
            gameOverImage.sprite = GameAssets.Instance.YellowWin;
        }
        if (snake.CompareTag("SecondSnakeHead"))
        {
            //Green win
            gameOverImage.sprite = GameAssets.Instance.GreenWin;
        }

        //Check for segment collide with another snake (Yollow and Green WIN)

        if (!Lobby.isSecondSnakeSpawn)
        {
            gameOverImage.sprite = GameAssets.Instance.GameOver;
        }

        SoundManager.Instance.GameOverMusic(Sounds.GameOver);
        SoundManager.Instance.backgroundMusic.Pause();
        SoundManager.Instance.snakeRattleMusic.Pause();
       
        gameOverPanel.SetActive(true);

    }

    public void DrawCondition()
    {
        gameOverImage.sprite = GameAssets.Instance.Draw;
        
        SoundManager.Instance.GameOverMusic(Sounds.GameOver);
        SoundManager.Instance.backgroundMusic.Pause();
        SoundManager.Instance.snakeRattleMusic.Pause();
        
        gameOverPanel.SetActive(true);
    }
}
