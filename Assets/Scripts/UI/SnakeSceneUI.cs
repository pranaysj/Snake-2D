using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnakeSceneUI : MonoBehaviour
{
    private GameObject menuBackgroundPanelOfPausePanel;
    private GameObject menuBackgroundPanelOfGameOverPanel;

    private Button pauseButton;
    public Button resumeButton;
    public Button restartButton;

    public Button gameOverRestartButton;

    public GameObject transitionPanel;

    private SnakeCollision snakeCollision;

    private bool isGameOverPanelactive = true;

    private void Awake()
    {
        transitionPanel = transform.GetChild(4).gameObject;
        Invoke("TransitionPanel", 1.8f);
    }
    void Start()
    {
        pauseButton = transform.GetChild(1).gameObject.GetComponent<Button>();
        pauseButton.onClick.AddListener(MenuPanel);

        menuBackgroundPanelOfPausePanel = transform.GetChild(2).gameObject;

        resumeButton = transform.GetChild(2).GetChild(0).GetChild(0).gameObject.GetComponent<Button>();
        resumeButton.onClick.AddListener(Resume);
        
        restartButton = transform.GetChild(2).GetChild(0).GetChild(1).gameObject.GetComponent<Button>();
        restartButton.onClick.AddListener(Restart);
        
        menuBackgroundPanelOfGameOverPanel = transform.GetChild(3).gameObject;

        gameOverRestartButton = transform.GetChild(3).GetChild(0).GetChild(1).gameObject.GetComponent<Button>();
        gameOverRestartButton.onClick.AddListener(Restart);

        snakeCollision = GameObject.Find("Snake").GetComponent<SnakeCollision>();

    }

    private void TransitionPanel()
    {
        transitionPanel.SetActive(false);
    }

    private void MenuPanel()
    {
        menuBackgroundPanelOfPausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void Resume()
    {
        menuBackgroundPanelOfPausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void Restart()
    {
        Time.timeScale = 1.0f;
        transitionPanel.SetActive(true);
        StartCoroutine(TransitionPanel(1.5f));
    }

    private IEnumerator TransitionPanel(float delay)
    {
        Animator animator = transitionPanel.GetComponent<Animator>();
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Lobby");
    }

    private void Update()
    {
        if (snakeCollision.snakeIsDeath && isGameOverPanelactive)
        {
            isGameOverPanelactive = false;
            //activate the Game over panel
            StartCoroutine(GameOverPanel(0.5f));
        }
    }

    private IEnumerator GameOverPanel(float delay)
    {
        yield return new WaitForSeconds(delay);
        menuBackgroundPanelOfGameOverPanel.SetActive(true);
    }
}
