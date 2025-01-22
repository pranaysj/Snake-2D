using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public enum Sounds
{
    BackgroundMusic,
    ButtonClick,
    ItemCollect,
    PowerUpCollect,
    GameOver,
    SnakeRattle
}

[Serializable]
public class SoundTypes
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance;  } }

    public SoundTypes[] sounds;

    [Header("AUDIO SOURCES")]
    public AudioSource backgroundMusic;
    public AudioSource buttonClickSound;
    public AudioSource itemCollectSound;
    public AudioSource gameOverMusic;
    public AudioSource snakeRattleMusic;

    private float volumne = 1.0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundTypes item = Array.Find(sounds, item => item.soundType == sound);
        if (item != null)
        {
            return item.soundClip;
        }
        return null;
    }

    void Start()
    {
        SetVolumne(0.5f);
        PlayMusic(Sounds.BackgroundMusic);
    }

    private void SetVolumne(float volumne)
    {
        this.volumne = volumne;
        backgroundMusic.volume = volumne;
        buttonClickSound.volume = volumne;
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);

        if (clip != null)
        {
            backgroundMusic.clip = clip;
            backgroundMusic.Play();
        }
        else
        {
            Debug.LogError("Audio clip is not found....." + sound);
        }
    }

    public void GameOverMusic(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);

        if (clip != null)
        {
            gameOverMusic.clip = clip;
            gameOverMusic.Play();
        }
        else
        {
            Debug.LogError("Audio clip is not found....." + sound);
        }
    }

    public void SnakeRattleMusic(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);

        if (clip != null)
        {
            snakeRattleMusic.clip = clip;
            snakeRattleMusic.Play();
        }
        else
        {
            Debug.LogError("Audio clip is not found....." + sound);
        }
    }

    public void ButtonClickSound(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);

        if (clip != null)
        {
            buttonClickSound.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Audio clip is not found....." + sound);
        }
    }

    public void ItemCollectSound(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);

        if (clip != null)
        {
            itemCollectSound.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Audio clip is not found....." + sound);
        }
    }


}
