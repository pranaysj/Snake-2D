using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SnakeCollision : MonoBehaviour
{
    private SnakeBody body;
    private ScoreText scoreText;
    public bool snakeIsDeath = false;

    private void Start()
    {
        body = GetComponent<SnakeBody>();
        scoreText = GameObject.Find("Score").GetComponent<ScoreText>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SnakeTail")
        {
            Debug.Log("DEATH");
            snakeIsDeath = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Apple")
        {
            scoreText.Score(1);
            Destroy(collision.gameObject);
            body.SpawnBodyPart();

        }

        if (collision.gameObject.tag == "FruitBasket")
        {
            scoreText.Score(2);
            Destroy(collision.gameObject);
            StartCoroutine(SpawnSegment());
        }

        if (collision.gameObject.tag == "BitterGourd")
        {
            scoreText.Score(-2);
            Destroy(collision.gameObject);
            //minus the last body segment
            StartCoroutine(RemoveSegment());
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

}
