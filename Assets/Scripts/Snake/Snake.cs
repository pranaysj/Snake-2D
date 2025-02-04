using UnityEngine;

public class Snake : SnakeBase
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

        //Set the Input button for snake
        handleInput.GetInput();


        segment.segments.Add(this.gameObject);

        SpawnSegment();
    }

    private void Update()
    {
        //get the head postion 
        currentPosition = transform.position;

        //warp the head when get through the boarder
        wrappedPosition = screenWrap.Wrapping(currentPosition);
        transform.position = wrappedPosition;

        //Spawn segment when press space button
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnSegment();
        }

        //Assign input buttons
        move.SnakeDirection = handleInput.InputButton(move.SnakeDirection);
    }

    private void FixedUpdate()
    {
        //Head movement
        //transform.position += move.MoveForward();
        transform.Translate(move.MoveForward());

        //Segment follow the head
        segment.Follow(move.SnakeSpeed, move.SnakeDirection);

        //Draw red line between segments
        for (int i = 1; i < segment.segments.Count; i++)
        {
            Debug.DrawLine(segment.segments[i - 1].transform.position, segment.segments[i].transform.position, Color.red);
        }
    }

    public void SpawnSegment()
    {
        Vector3 pos = segment.segments[segment.segments.Count - 1].transform.position - move.SnakeDirection * 0.3f;
        segment.Grow(Instantiate(segmentPrefab, pos, Quaternion.identity));
    }
}
