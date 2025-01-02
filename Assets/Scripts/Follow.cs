using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private SnakeBody snakeBody;
    private SnakeMovement snakeMovement;

    private Vector3 targetPosition;

    private Transform snakeTurn;
    [SerializeField]private List<Transform> snakeTurnPositoin = new List<Transform>();
    [SerializeField]private SnakeMovement.HeadDircetion previouHeadDirection;

    private void Start()
    {
        snakeBody = GetComponent<SnakeBody>();
        snakeMovement = GetComponent<SnakeMovement>();

        previouHeadDirection = SnakeMovement.HeadDircetion.RIGHT;
    }

    private void FixedUpdate()
    {
        SnakeDirection();
    }

    // make some changes for nsake speed
    private void SnakeDirection()
    {
        if (snakeMovement.headDirection != previouHeadDirection)
        {
            snakeTurnPositoin.Add(transform);
            previouHeadDirection = snakeMovement.headDirection;
        }
    }
}
