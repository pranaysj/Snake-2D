using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SnakeMovement : MonoBehaviour
{
    private Vector2 snakeDirection = Vector2.zero;
    [SerializeField] private float snakeSpeed = 2.0f;

    public float SnakeSpeed
    {
        get { return snakeSpeed; }
        set { snakeSpeed = value; }
    }

    public Vector2 SnakeDirection
    {
        get { return snakeDirection; }
        set { snakeDirection = value; }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && SnakeDirection != Vector2.down)
        {
            SnakeDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && SnakeDirection != Vector2.up)
        {
            SnakeDirection = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && SnakeDirection != Vector2.left)
        {
            SnakeDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && SnakeDirection != Vector2.right)
        {
            SnakeDirection = Vector2.left;
        }

    }

    private void FixedUpdate()
    {
        transform.Translate(SnakeDirection * SnakeSpeed * Time.deltaTime);
        
    }

}
