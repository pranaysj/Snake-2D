using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Segment
{
    public List<GameObject> segments = new List<GameObject>();
    private Movement move;

    public void Grow(GameObject seg)
    {
        segments.Add(seg);
    }

    public void Follow(float speed, Vector3 direction)
    {
        Debug.Log("HEAD : "+ segments[0].transform.position);
        Debug.Log("Tail : " + segments[1].transform.position);

        //segments[1].transform.position = segments[0].transform.position - dircetion * 0.3f;

        for (int i = 0; i < segments.Count; i++)
        {
            if (i+1 > segments.Count) break;
            segments[i + 1].transform.position = segments[i].transform.position - direction * 0.3f;

        }

    }
}
