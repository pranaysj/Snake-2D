using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    public List<GameObject> body = new List<GameObject>();
    public GameObject segmentPrefab;

    private void Start()
    {
        body.Add(gameObject);
    }

    private void Update()
    {
        //Spawn segment when press space button
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnSegment();
        }
    }

    public void SpawnSegment()
    {
        GameObject lastSegment = body[body.Count - 1];
        GameObject segement = Instantiate(segmentPrefab);
        Segment segmentScript = segement.GetComponent<Segment>();
        segmentScript.InitializeSegement(lastSegment);
        body.Add(segement);
    }


}
