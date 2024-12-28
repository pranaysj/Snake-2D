using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private SnakeBody snakeBody;
    private SnakeMovement snakeMovement;
    private GameObject previoustail;

    private List<Vector3> nextPosition = new List<Vector3>();
    public float followDelay = 1.5f; // Delay in seconds
    private float timer;


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

        float desiredDistance = 0.3f; // Adjust as needed
        Vector3 directionToPrevious = (previoustail.transform.position - transform.position).normalized;
        transform.position = previoustail.transform.position - directionToPrevious * desiredDistance;

    }
}
