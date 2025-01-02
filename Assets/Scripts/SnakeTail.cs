using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    private GameObject snake;
    private SnakeBody snakeBody;
    private SnakeMovement snakeMovement;
    private Follow follow;

    [SerializeField]private GameObject frontTail;
    private float diff = 0.3f;
    private Vector3 difference;


    void Start()
    {
        snake = GameObject.Find("Snake");
        snakeBody = snake.GetComponent<SnakeBody>();
        snakeMovement = snake.GetComponent<SnakeMovement>();
        follow = snake.GetComponent<Follow>();

        frontTail = snakeBody.BodyParts[snakeBody.BodyParts.Count-2];
    }

    void FixedUpdate()
    {
        //Follow the front tail     -        
        //Maintain the 0.3f distance

    }

}  
