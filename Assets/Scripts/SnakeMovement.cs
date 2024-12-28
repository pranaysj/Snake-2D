using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeMovement : MonoBehaviour
{
    private Vector3 snakeDirection = Vector3.zero;
    private float snakeSpeed = 2.0f;

    public float SnakeSpeed
    {
        get { return snakeSpeed; }
        set { snakeSpeed = value; }
    }

    public Vector3 SnakeDirection
    {
        get { return snakeDirection; }
        set { snakeDirection = value; }
    }

    private void Start()
    {
        SpriteRenderer snakeSprite = gameObject.AddComponent<SpriteRenderer>();
        snakeSprite.sprite = GameAssets.Instance.snake;
        snakeSprite.color = Color.green;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && SnakeDirection != Vector3.down)
        {
            SnakeDirection = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && SnakeDirection != Vector3.up)
        {
            SnakeDirection = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && SnakeDirection != Vector3.left)
        {
            SnakeDirection = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && SnakeDirection != Vector3.right)
        {
            SnakeDirection = Vector3.left;
        }
        transform.Translate(SnakeDirection * SnakeSpeed * Time.deltaTime);

    }

}
