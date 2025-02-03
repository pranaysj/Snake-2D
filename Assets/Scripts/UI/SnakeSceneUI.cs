using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnakeSceneUI : MonoBehaviour
{
    //public GameObject menuBackgroundPanelOfPausePanel;
    //public GameObject menuBackgroundPanelOfGameOverPanel;
    //public GameObject transitionPanel;

    //public Image gameOverImage;

    //private bool isGameOverPanelActive = true;


    //public GameManager playerManager;
    //private SnakeCollision snake1collision;
    //private SnakeCollision snake2collision;

    //private S_SnakeCollision secondSnakeCollision;

    //private ScoreText scoreText;
    //private S_ScoreText scoreText2;

    //private void Awake()
    //{
    //    transitionPanel = transform.GetChild(4).gameObject;
    //    Invoke("TransitionPanel", 1.8f);
    //}
    //void Start()
    //{
    //    snake1collision = GameObject.Find("Snake").GetComponent<SnakeCollision>();
    //    GameObject secondSnake = GameObject.Find("SecondSnake");
    //    if (secondSnake != null) secondSnakeCollision = secondSnake.GetComponent<S_SnakeCollision>();

    //    scoreText = GetComponent<ScoreText>();
    //    scoreText2 = GetComponent<S_ScoreText>();

    //}

    //private void TransitionPanel()
    //{
    //    transitionPanel.SetActive(false);
    //}

    //public void MenuPanel()
    //{
    //    //SoundManager.Instance.ButtonClickSound(Sounds.ButtonClick);
    //    //SoundManager.Instance.snakeRattleMusic.Pause();

    //    menuBackgroundPanelOfPausePanel.SetActive(true);
    //    Time.timeScale = 0.0f;
    //}

    //public void Resume()
    //{
    //    //SoundManager.Instance.ButtonClickSound(Sounds.ButtonClick);
    //    //SoundManager.Instance.snakeRattleMusic.Play();

    //    menuBackgroundPanelOfPausePanel.SetActive(false);
    //    Time.timeScale = 1.0f;
    //}

    //public void Restart()
    //{
    //    //SoundManager.Instance.ButtonClickSound(Sounds.ButtonClick);
    //    //SoundManager.Instance.backgroundMusic.Play();
    //    //SoundManager.Instance.gameOverMusic.Pause();

    //    Time.timeScale = 1.0f;
    //    transitionPanel.SetActive(true);
    //    StartCoroutine(TransitionPanel(1.5f));
    //}

    //private IEnumerator TransitionPanel(float delay)
    //{
    //    Animator animator = transitionPanel.GetComponent<Animator>();
    //    animator.SetTrigger("FadeIn");
    //    yield return new WaitForSeconds(delay);
    //    SceneManager.LoadScene("Lobby");
    //}

    //private void Update()
    //{
    //    //FOR 1st Snake- SELF COLLISION
    //    if (snake1collision.snake1IsDeath && isGameOverPanelActive)
    //    {
    //        isGameOverPanelActive = false;
    //        StartCoroutine(GameOverPanel(1.5f));
    //        if (SceneManager.GetActiveScene().name == "Two Snakes")
    //        {
    //            gameOverImage.sprite = GameAssets.Instance.YellowWin;
    //        }
    //    }

    //    //FOR 2nd Snake - SELF COLLISION
    //    //if (secondSnakeCollision != null)
    //    if (SceneManager.GetActiveScene().buildIndex == 2)
    //    {
    //        if (snake2collision.snake2IsDeath && isGameOverPanelActive)
    //        {
    //            isGameOverPanelActive = false;
    //            StartCoroutine(GameOverPanel(1.5f));
    //            gameOverImage.sprite = GameAssets.Instance.GreenWin;
    //        }
    //    }



    //    //if (SceneManager.GetActiveScene().name == "Two Snakes")
    //    if (SceneManager.GetActiveScene().buildIndex == 2)
    //    {
    //        //1st snake collide with 2nd snake body
    //        if (snake1collision.snake1Collide && isGameOverPanelActive)
    //        {
    //            isGameOverPanelActive = false;
    //            StartCoroutine(GameOverPanel(1.5f));
    //            gameOverImage.sprite = GameAssets.Instance.YellowWin;

    //        }

    //        //2nd snake collide with 1st snake body
    //        if (secondSnakeCollision.snakeCollide && isGameOverPanelActive)
    //        {
    //            isGameOverPanelActive = false;
    //            StartCoroutine(GameOverPanel(1.5f));
    //            gameOverImage.sprite = GameAssets.Instance.GreenWin;

    //        }

    //        //When both snake head collide
    //        if (secondSnakeCollision.snakeHeadCollide && isGameOverPanelActive)
    //        {
    //            isGameOverPanelActive = false;
    //            StartCoroutine(ScoreCompare(1.5f));

    //        }
    //    }
    //}

    //private IEnumerator GameOverPanel(float delay)
    //{
    //    yield return new WaitForSeconds(delay);
    //    menuBackgroundPanelOfGameOverPanel.SetActive(true);
    //    GameOverMusic();
    //}

    //private IEnumerator ScoreCompare(float delay)
    //{
    //    if (scoreText.score > scoreText2.score)
    //    {
    //         gameOverImage.sprite = GameAssets.Instance.GreenWin;
    //    }

    //    if (scoreText.score < scoreText2.score)
    //    {
    //        gameOverImage.sprite = GameAssets.Instance.YellowWin;
    //    }

    //    if (scoreText.score == scoreText2.score)
    //    {
    //        gameOverImage.sprite= GameAssets.Instance.Draw;
    //    }

    //    yield return new WaitForSeconds(delay);
    //    menuBackgroundPanelOfGameOverPanel.SetActive(true);
    //    GameOverMusic();
    //}

    //private void GameOverMusic()
    //{
    //    SoundManager.Instance.GameOverMusic(Sounds.GameOver);
    //    SoundManager.Instance.backgroundMusic.Pause();
    //    SoundManager.Instance.snakeRattleMusic.Pause();
    //}
}
