using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class SnakeCollision : MonoBehaviour
{
    private SnakeBody body;
    private SnakeMovement snakeMov;
    private ScoreText scoreText;
    public bool snakeIsDeath = false;
    [SerializeField]public bool scoreBosster = false;


    private void Start()
    {
        body = GetComponent<SnakeBody>();
        snakeMov = GetComponent<SnakeMovement>();
        scoreText = GameObject.Find("Score").GetComponent<ScoreText>();

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SnakeTail")
        {
            snakeMov.enabled = false; //Disable the Movement Script when sckae death.
            snakeIsDeath = true;
        }

        if (collision.gameObject.tag == "Apple")
        {
            scoreText.Score(2, scoreBosster);
            Destroy(collision.gameObject);
            body.SpawnBodyPart();

        }

        if (collision.gameObject.tag == "FruitBasket")
        {
            scoreText.Score(3, scoreBosster);
            Destroy(collision.gameObject);
            StartCoroutine(SpawnSegment());
        }

        if (collision.gameObject.tag == "BitterGourd")
        {
            scoreText.Score(-2);
            Destroy(collision.gameObject);
            StartCoroutine(RemoveSegment());
        }

        if (collision.gameObject.tag == "ScoreBoost")
        {
            Destroy(collision.gameObject);
            StartCoroutine(ScoreBooster());
        }

        if (collision.gameObject.tag == "Shield")
        {
            Destroy(collision.gameObject);
            StartCoroutine(Shield());
        }

        if (collision.gameObject.tag == "SpeedUp")
        {
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
            if (i == 2) body.BodyParts[i].transform.gameObject.tag = "SafeTail";

            body.BodyParts[i].transform.gameObject.tag = "SnakeTail";
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
