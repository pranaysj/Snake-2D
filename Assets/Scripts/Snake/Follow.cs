using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    //[SerializeField] private int positionHistorySize = 50;
    //private readonly List<Vector3> positionHistory = new();
    //private Vector3 previousPosition;

    //private void Start()
    //{
    //    previousPosition = transform.position;
    //    positionHistory.Add(transform.position);
    //}

    private void FixedUpdate()
    {
        // Wrap the current position using the shared utility.
        Vector3 currentPosition = ScreenWrap.Wrapping(transform.position);
        transform.position = currentPosition;

        //// Update history if the position has changed.
        //if (transform.position != previousPosition)
        //{
        //    positionHistory.Add(transform.position);
        //    if (positionHistory.Count > positionHistorySize)
        //        positionHistory.RemoveAt(0);
        //    previousPosition = transform.position;
        //}
    }
}