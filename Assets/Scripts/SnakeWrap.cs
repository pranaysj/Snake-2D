using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeWrap : MonoBehaviour
{
    private Vector2 screenBound;
    private SnakeMovement snake;

    void Start()
    {
        Camera mainCamera = Camera.main;
        screenBound = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        snake = GetComponent<SnakeMovement>();  
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 snakePosition = snake.transform.position;

        //Up and Down Wrap
        if (snakePosition.y > screenBound.y)
        {
            snakePosition.y = -screenBound.y;
        }
        else if (snakePosition.y < -screenBound.y)
        {
            snakePosition.y = screenBound.y;
        }

        //Left and  Right Wrap
        if (snakePosition.x > screenBound.x)
        {
            snakePosition.x = -screenBound.x;
        }
        else if (snakePosition.x < -screenBound.x)
        {
            snakePosition.x = screenBound.x;
        }

        transform.position = snakePosition;
    }
}
