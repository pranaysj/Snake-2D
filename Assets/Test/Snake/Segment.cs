using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment  
{
    public List<GameObject> segments = new List<GameObject>();
    ScreenWrap screenWrap = new ScreenWrap();

    Vector3 nextSeg = Vector3.zero;

    //Only body grow and follow
    public void Grow(GameObject seg)
    {
       // nextSeg = seg.transform.position ; //Snake Haed positon
        segments.Add(seg);
    }

    public void Follow(Vector3 headPosition, float speed)
    {
        Vector3 previousPosition = headPosition;



        for (int i = 0; i < segments.Count; i++)
        {
            Vector3 temp = segments[i].transform.position;
            segments[i].transform.position = Vector3.Lerp(temp, previousPosition, speed * Time.fixedDeltaTime);
            previousPosition = temp;

            //segments[i].transform.position = screenWrap.Wrapping(segments[i].transform.position);

        }

    }
}
