using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    [Header("PANEL 1")]
    public Button playButton;
    public Animator titlePanelAnimator;

    [Header("PANEL 2")]
    public GameObject playModePanelGameObject;
    public Button onePlayerButton;
    public Button twoPlayerButton;
    public Animator playModePanelAnimator;

    private void Awake()
    {
        playButton.onClick.AddListener(Play);
        onePlayerButton.onClick.AddListener(OnePlayer);
        twoPlayerButton.onClick.AddListener(TwoPlayer);
    }

    private void Play()
    {
        //Fade Out animation
        titlePanelAnimator.SetTrigger("Play");
        SoundManager.Instance.ButtonClickSound(Sounds.ButtonClick);
        //Delay to activate the gameObject
        StartCoroutine(ActivateGameObject(playModePanelGameObject, 1.0f));
    }

    private IEnumerator ActivateGameObject(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(true);
    }

    private void OnePlayer()
    {
        playModePanelAnimator.SetTrigger("FadeOut");
        SoundManager.Instance.ButtonClickSound(Sounds.ButtonClick);

        StartCoroutine(SceneLoader("Snake", 1.0f));
    }

    private void TwoPlayer()
    {
        playModePanelAnimator.SetTrigger("FadeOut");
        SoundManager.Instance.ButtonClickSound(Sounds.ButtonClick);

        StartCoroutine(SceneLoader("Two Snakes", 1.0f));

    }

    private IEnumerator SceneLoader(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        //Snake Scene load
        SceneManager.LoadScene(sceneName);
    }
}
