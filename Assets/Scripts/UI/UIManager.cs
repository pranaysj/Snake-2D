using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject menuPanel_BG_Pause;
    public GameObject menuPanel_BG_GameOverl;
    public GameObject transitionPanel;

    private readonly float transitionDelay = 1.8f;

    private void Start()
    {
        Invoke(nameof(TransitionPanelDeactivate), transitionDelay);
    }

    public void Pause()
    {
        menuPanel_BG_Pause.SetActive(true);
        Time.timeScale = 0.0f;
        SoundManager.Instance.ButtonClickSound(Sounds.ButtonClick);
        SoundManager.Instance.snakeRattleMusic.Pause();
    }

    public void Resume()
    {
        menuPanel_BG_Pause.SetActive(false);
        Time.timeScale = 1.0f;
        SoundManager.Instance.ButtonClickSound(Sounds.ButtonClick);
        SoundManager.Instance.snakeRattleMusic.Play();
    }

    public void Restart()
    {
        SoundManager.Instance.ButtonClickSound(Sounds.ButtonClick);
        SoundManager.Instance.backgroundMusic.Play();
        SoundManager.Instance.gameOverMusic.Pause();

        Time.timeScale = 1.0f;
        transitionPanel.SetActive(true);

        Lobby.isSecondSnakeSpawn = false;
        HandleInput.lastInput = false;
        Movement.lastDirection = false;

        StartCoroutine(TransitionPanelActivate(transitionDelay));
    }

    private void TransitionPanelDeactivate()
    {
        transitionPanel.SetActive(false);
    }

    private IEnumerator TransitionPanelActivate(float delay)
    {
        Animator animator = transitionPanel.GetComponent<Animator>();
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nameof(Lobby));
    }

}
