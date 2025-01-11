using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private SnakeBody snakeBody;
    private SnakeMovement snakeMovement;
    private GameObject previoustail;
    private float desiredDistance = 0.3f; // Adjust as needed


    private void Start()
    {
        GameObject snake = GameObject.Find("Snake");
        snakeBody = snake.GetComponent<SnakeBody>();
        snakeMovement = snake.GetComponent<SnakeMovement>();

        int count = snakeBody.BodyParts.Count;
        previoustail = snakeBody.BodyParts[count - 2];
    }

    void Update()
    {

        Vector3 directionToPrevious = (previoustail.transform.position - transform.position).normalized;
        transform.position = previoustail.transform.position - directionToPrevious * desiredDistance;

    }
}
