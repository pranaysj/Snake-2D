using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeMovement : MonoBehaviour
{
    public enum HeadDircetion
    {
        UP, DOWN, LEFT, RIGHT
    };

    private Vector3 snakeDirection;
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
            SnakeDirection = SnakeHeadDirection(HeadDircetion.UP);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && SnakeDirection != Vector3.up)
        {
            SnakeDirection = SnakeHeadDirection(HeadDircetion.DOWN);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && SnakeDirection != Vector3.left)
        {
            SnakeDirection = SnakeHeadDirection(HeadDircetion.RIGHT);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && SnakeDirection != Vector3.right)
        {
            SnakeDirection = SnakeHeadDirection(HeadDircetion.LEFT);
        }

        transform.Translate(SnakeDirection * SnakeSpeed * Time.deltaTime);

    }

    public Vector3 SnakeHeadDirection(HeadDircetion direction)
    {
        switch (direction)
        {
            case HeadDircetion.UP: return Vector3.up;
            case HeadDircetion.DOWN: return Vector3.down;
            case HeadDircetion.LEFT: return Vector3.left;
            case HeadDircetion.RIGHT: return Vector3.right;
            default: return Vector3.down;
        }
    }

}
