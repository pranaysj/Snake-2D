using UnityEngine;

public class Movement
{

   

    [SerializeField] private float snakeSpeed = 2.0f;


    public static bool lastDirection = false;
    private Vector3 snakeDirection = Vector3.right;



    public Vector3 SnakeDirection
    {
        get { return snakeDirection; }
        set { snakeDirection = value; }
    }
    public float SnakeSpeed
    {
        get { return snakeSpeed; }
        set { snakeSpeed = value; }
    }

    public void Dircetion()
    {
        lastDirection = !lastDirection;
        SnakeDirection = lastDirection ? Vector2.right : Vector2.left;
    }

    public Vector3 MoveForward()
    {
        return SnakeDirection * SnakeSpeed * Time.deltaTime;
    }

   
   
}
