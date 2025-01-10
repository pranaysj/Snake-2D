using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    private SnakeBody snakeBody;
<<<<<<< Updated upstream
    private SnakeMovement snakeMovement;

    private Vector3 targetPosition;

    private Transform snakeTurn;
    [SerializeField]private List<Transform> snakeTurnPositoin = new List<Transform>();
    [SerializeField]private SnakeMovement.HeadDircetion previouHeadDirection;

    private void Start()
    {
        snakeBody = GetComponent<SnakeBody>();
        snakeMovement = GetComponent<SnakeMovement>();
=======
    //private SnakeMovement snakeMovement;
    private GameObject previoustail;

    //private List<Vector3> nextPosition = new List<Vector3>();
    //public float followDelay = 1.5f; // Delay in seconds
    //private float timer;

    private float desiredDistance = 0.3f; // Adjust as needed
//<<<<<<< Updated upstream
//=======
    //private Transform snakeTurn;
    //[SerializeField]private List<Transform> snakeTurnPositoin = new List<Transform>(); //A queue of VEctor3
    //[SerializeField]private SnakeMovement.HeadDircetion previouHeadDirection;
//>>>>>>> Stashed changes

    private void Start()
    {
        GameObject snake = GameObject.Find("Snake");
        snakeBody = snake.GetComponent<SnakeBody>();
        //snakeMovement = snake.GetComponent<SnakeMovement>();
>>>>>>> Stashed changes

        previouHeadDirection = SnakeMovement.HeadDircetion.RIGHT;
    }

    private void FixedUpdate()
    {
        SnakeDirection();
    }

<<<<<<< Updated upstream
    // make some changes for nsake speed
    private void SnakeDirection()
    {
        if (snakeMovement.headDirection != previouHeadDirection)
        {
            snakeTurnPositoin.Add(transform);
            previouHeadDirection = snakeMovement.headDirection;
        }
=======
        Vector3 directionToPrevious = (previoustail.transform.position - transform.position).normalized;
        transform.position = previoustail.transform.position - directionToPrevious * desiredDistance;

>>>>>>> Stashed changes
    }
}
