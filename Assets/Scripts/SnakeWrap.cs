using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeWrap : MonoBehaviour
{
    private Vector3 screenBound;
    private Vector2 screenMinimum;

    private SnakeMovement snake;

    private SnakeBody snakeBody;

    private Transform snakeHead;
    private Vector2 newSnakeHeadPosition;
    private Vector2 SnakeHeadPosition;

    private bool needsWrap;

    void Start()
    {
        Camera mainCamera = Camera.main;
        screenBound = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        screenMinimum = mainCamera.ScreenToWorldPoint(new Vector2(0.0f, 0.0f));


        snake = GetComponent<SnakeMovement>();
        snakeBody = GetComponent<SnakeBody>();

    }

    void Update()
    {

        if (snakeBody == null || snakeBody.BodyParts == null)
        {
            return;
        }

        snakeHead = snakeBody.BodyParts[0].transform;
        newSnakeHeadPosition = SnakeHeadPosition = snakeHead.position;

        needsWrap = false;

        if (SnakeHeadPosition.x > screenBound.x)
        {
            newSnakeHeadPosition.x = screenMinimum.x + 0.1f;
            needsWrap = true;
        }
        else if (SnakeHeadPosition.x < screenMinimum.x)
        {
            newSnakeHeadPosition.x = screenBound.x - 0.1f;
            needsWrap = true;
        }

        if (SnakeHeadPosition.y > screenBound.y)
        {
            newSnakeHeadPosition.y = screenMinimum.y + 0.1f;
            needsWrap = true;
        }
        else if (SnakeHeadPosition.y < screenMinimum.y)
        {
            newSnakeHeadPosition.y = screenBound.y - 0.1f;
            needsWrap = true;
        }

        if (needsWrap)
        {
            snakeHead.position = newSnakeHeadPosition;
            Vector2 offset = newSnakeHeadPosition - SnakeHeadPosition;

            /*
            foreach (var seg in snakeBody.BodyParts)
            {
                if (seg != null)
                {
                    seg.transform.position += (Vector3)offset;
                }
            }
            */
            for (int i = 1; i < snakeBody.BodyParts.Count; i++)
            {
                if (snakeBody.BodyParts[i] != null)
                {
                    snakeBody.BodyParts[i].transform.position += (Vector3)offset;

                }
            }
        }
        /*
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
        */

    }
}
