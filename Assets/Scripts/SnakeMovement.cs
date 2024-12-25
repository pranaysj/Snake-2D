using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeMovement : MonoBehaviour
{
    private Vector2 snakeDirection = Vector2.zero;
    private float snakeSpeed = 2.0f;

    private void Start()
    {
        SpriteRenderer snakeSprite = gameObject.AddComponent<SpriteRenderer>();
        snakeSprite.sprite = GameAssets.Instance.snake;
        snakeSprite.color = Color.green;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && snakeDirection != Vector2.down)
        {
            snakeDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && snakeDirection != Vector2.up)
        {
            snakeDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && snakeDirection != Vector2.left)
        {
            snakeDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && snakeDirection != Vector2.right)
        {
            snakeDirection = Vector2.left;
        }

        transform.Translate(snakeDirection * snakeSpeed * Time.deltaTime);

    }

}
