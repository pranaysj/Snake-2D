using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class S_SnakeCollision : MonoBehaviour
{
    private S_SnakeBody body;
    private S_SnakeMovement snakeMov;
    private S_ScoreText scoreText;
    public bool snakeIsDeath = false;
    public bool snakeCollide = false;
    public bool snakeHeadCollide = false;
    [SerializeField]public bool scoreBosster = false;


    private void Start()
    {
        body = GetComponent<S_SnakeBody>();
        snakeMov = GetComponent<S_SnakeMovement>();
        scoreText = GameObject.Find("Canvas").GetComponent<S_ScoreText>();

    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FirstSnakeHead")
        {
            snakeMov.enabled = false; //Disable the Movement Script when sckae death.
            GameObject gameObject = GameObject.Find("Snake");
            SnakeMovement firstSnake = gameObject.GetComponent<SnakeMovement>();
            firstSnake.enabled = false; // Disable the Movement Script when sckae death
            snakeHeadCollide = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SecondSnakeTail")
        {
            snakeMov.enabled = false; //Disable the Movement Script when sckae death.
            snakeIsDeath = true;
        }

        if (collision.gameObject.tag == "SnakeTail")
        {
            snakeMov.enabled = false;
            GameObject gameObject = GameObject.Find("Snake");
            SnakeMovement firstSnake = gameObject.GetComponent<SnakeMovement>();
            firstSnake.enabled = false; // Disable the Movement Script when sckae death
            snakeCollide = true;

        }


        if (collision.gameObject.tag == "Apple")
        {
            SoundManager.Instance.ItemCollectSound(Sounds.ItemCollect);

            scoreText.Score(2, scoreBosster);
            Destroy(collision.gameObject);
            body.SpawnBodyPart();

        }

        if (collision.gameObject.tag == "FruitBasket")
        {
            SoundManager.Instance.ItemCollectSound(Sounds.ItemCollect);

            scoreText.Score(3, scoreBosster);
            Destroy(collision.gameObject);
            StartCoroutine(SpawnSegment());
        }

        if (collision.gameObject.tag == "BitterGourd")
        {
            SoundManager.Instance.ItemCollectSound(Sounds.ItemCollect);

            scoreText.Score(-2);
            Destroy(collision.gameObject);
            StartCoroutine(RemoveSegment());
        }

        if (collision.gameObject.tag == "ScoreBoost")
        {
            SoundManager.Instance.ItemCollectSound(Sounds.PowerUpCollect);

            Destroy(collision.gameObject);
            StartCoroutine(ScoreBooster());
        }

        if (collision.gameObject.tag == "Shield")
        {
            SoundManager.Instance.ItemCollectSound(Sounds.PowerUpCollect);

            Destroy(collision.gameObject);
            StartCoroutine(Shield());
        }

        if (collision.gameObject.tag == "SpeedUp")
        {
            SoundManager.Instance.ItemCollectSound(Sounds.PowerUpCollect);

            Destroy(collision.gameObject);
            StartCoroutine(SnakeSpeedUp());
        }
    }

    private IEnumerator SpawnSegment()
    {
        body.SpawnBodyPart();
        yield return new WaitForSeconds(0.2f);
        body.SpawnBodyPart();
    }

    private IEnumerator RemoveSegment()
    {
        body.RemoveBodyPart();
        yield return new WaitForSeconds(0.2f);
        body.RemoveBodyPart();
    }

    private IEnumerator ScoreBooster()
    {
        scoreBosster = true;
        yield return new WaitForSeconds(3.0f);
        scoreBosster = false;
    }

    private IEnumerator Shield()
    {
        InvokeRepeating("Shiel", 0.1f, 0.2f);

        yield return new WaitForSeconds(3.0f);

        CancelInvoke("Shiel");

        for (int i = 0; i < body.BodyParts.Count; i++)
        {
            body.BodyParts[i].transform.gameObject.tag = "SecondSnakeTail";

            if (i == 0) body.BodyParts[i].transform.gameObject.tag = "SecondSnakeHead";
            if (i == 1) body.BodyParts[i].transform.gameObject.tag = "SafeTail";
        }
    }

    private void Shiel()
    {
        for (int i = 0; i < body.BodyParts.Count; i++)
        {
            body.BodyParts[i].transform.gameObject.tag = "SafeTail";
        }
    }

    private IEnumerator SnakeSpeedUp()
    {
        snakeMov.SnakeSpeed = 4.0f;
        yield return new WaitForSeconds(3.0f);
        snakeMov.SnakeSpeed = 2.0f;
    }

}
