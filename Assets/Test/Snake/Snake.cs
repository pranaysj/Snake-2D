using UnityEngine;

public class Snake : SnakeManager
{
    public GameObject segmentPrefab;
    public Vector3 offset = Vector3.zero;

    Vector3 currentPosition;
    Vector3 wrappedPosition;

    private void Start()
    {
        //Initial direction left/right
        move.Dircetion();
        //Get the screen boundary fro wrapping
        screenWrap.ScreenBoundary();

        handleInput.GetInput();
    }

    private void Update()
    {
        currentPosition = transform.position;
        wrappedPosition = screenWrap.Wrapping(currentPosition);

        transform.position = wrappedPosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            offset = transform.position - move.SnakeDirection * 0.3f;

            segment.Grow(Instantiate(segmentPrefab, offset, Quaternion.identity));
        }

        //Assign input buttons
        move.SnakeDirection = handleInput.InputButton(move.SnakeDirection);
    }

    private void FixedUpdate()
    {
        transform.Translate(move.MoveForward());

        if (segment.segments != null)
        {
            segment.Follow(currentPosition, move.SnakeSpeed);
        }
    }
}
