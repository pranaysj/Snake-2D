using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private SnakeBody snakeBody;
    private SnakeMovement snakeMovement;
    private GameObject previoustail;
    private Vector3 targetPosition;

    [SerializeField]private List<Vector3> nextPosition = new List<Vector3>();


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
        //bool for evry turn on and off => Not possible because same script attach each and every object
        //Create new script for each Instatiate object => Possible if Direction is enum in snake Moveent class => ( NOT POSSIBLE BECAUSE WE CANNOT CREATE SCRIPT DYNAMICALLY   )

        if (snakeMovement.SnakeDirection == Vector3.up)
        {
            targetPosition = previoustail.transform.position - previoustail.transform.up * 0.3f;
        }
        else if (snakeMovement.SnakeDirection == Vector3.down)
        {
            targetPosition = previoustail.transform.position + previoustail.transform.up * 0.3f;
        }
        else if (snakeMovement.SnakeDirection == Vector3.right)
        {
            targetPosition = previoustail.transform.position - previoustail.transform.right * 0.3f;
        }
        else if (snakeMovement.SnakeDirection == Vector3.left)
        {
            targetPosition = previoustail.transform.position + previoustail.transform.right * 0.3f;
        }

        //try to insert above inside for loop

        nextPosition.Add(targetPosition);
        //nextPosition.Add(previoustail.transform.position);

        for (int i = 0; i < nextPosition.Count; i++)
        {
            transform.position = nextPosition[i];
            nextPosition.RemoveAt(i);
        }

        //float desiredDistance = 1.3f; // Adjust as needed
        //Vector3 directionToPrevious = (previoustail.transform.position - transform.position).normalized;
        //transform.position = previoustail.transform.position - directionToPrevious * desiredDistance;
        

    }
}
