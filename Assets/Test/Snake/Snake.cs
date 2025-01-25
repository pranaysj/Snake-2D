using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Snake : SnakeManager
{
    public GameObject seg;
    public Vector3 offset = Vector3.zero;

    private void Start()
    {
        move.Dircetion();
        screenWrap.ScreenBoundary();
    }

    private void Update()
    {
        transform.position = screenWrap.Wrapping(transform.position);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            offset = transform.position - move.SnakeDirection * 0.3f;

            segment.Grow(Instantiate(seg, offset, Quaternion.identity));
        }

    }

    private void FixedUpdate()
    {
        transform.Translate(move.MoveForward());

        if (segment.segments != null)
        {
            Vector3 currentPos = transform.position;
            segment.Follow(currentPos, move.SnakeSpeed);
        }
    }
}
