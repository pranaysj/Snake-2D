using UnityEngine;

public class Snake : SnakeBase , IPositionProvider
{


    public Vector3 offset = Vector3.zero;

    Vector3 currentPosition;
    Vector3 wrappedPosition;

    private void Start()
    {
        //Initial direction left/right
        move.Dircetion();

        //Get the screen boundary fro wrapping
        ScreenWrap.ScreenBoundary();

        //Set the Input button for snake
        handleInput.GetInput();

        currentPosition = transform.position;
    }

    private void Update()
    {
        //get the head postion 
        //currentPosition = transform.position;

        //warp the head when get through the boarder
        //wrappedPosition = ScreenWrap.Wrapping(currentPosition);
        //transform.position = wrappedPosition;

       

        //Assign input buttons
        move.SnakeDirection = handleInput.InputButton(move.SnakeDirection);
    }

    private void FixedUpdate()
    {
        //Head movement
        currentPosition += move.MoveForward();
        //transform.Translate(move.MoveForward());
        transform.position = ScreenWrap.Wrapping(currentPosition);

    }

    public Vector3 GetContinuousPosition()
    {
        return currentPosition;
    }
}
