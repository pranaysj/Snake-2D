using System.Collections.Generic;
using UnityEngine;

public class Segment  
{
    public List<GameObject> segments = new List<GameObject>();

    Vector3 previousPosition;

    private Vector3[] segmentPositions;


    public void Grow(GameObject seg)
    {
        segments.Add(seg);

        segmentPositions = new Vector3[segments.Count];
        for (int i = 0; i < segments.Count; i++)
        {
            segmentPositions[i] = segments[i].transform.position;
        }

    }

    public void Follow(Vector3 headPosition, float speed)
    {


        segmentPositions[0] = headPosition;

        // Move each segment to follow the one in front.
        for (int i = 1; i < segments.Count; i++)
        {
            Vector3 targetPosition = segmentPositions[i - 1] - (segments[i - 1].transform.forward * 0.2f);
            segmentPositions[i] = Vector3.MoveTowards(segmentPositions[i], targetPosition, speed * Time.fixedDeltaTime);
            segments[i].transform.position = segmentPositions[i];

            // Optional: Rotate the segment to face its direction of movement.
            //Vector3 direction = (segmentPositions[i - 1] - segmentPositions[i]).normalized;
            //if (direction != Vector3.zero)
            //{
            //    segments[i].rotation = Quaternion.LookRotation(direction);
            //}
        }

        //previousPosition  = headPosition;


        //for (int i = 0; i < segments.Count; i++)
        //{
        //    segments[i].transform.position = previousPosition;
        //    previousPosition = segments[i].transform.position;
        //    segments[i+1].transform.position = segments[i].transform.position;

        //    //Vector3 temp = segments[i].transform.position;
        //    //segments[i].transform.position = Vector3.Lerp(temp, previousPosition, speed * Time.fixedDeltaTime);
        //    //previousPosition = temp;
        //}
    }
}
