using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Segment : MonoBehaviour, IPositionProvider
{
    GameObject frontSegment;
    Vector3 currentPosition;

    IPositionProvider positionProvider;
    private Vector3 currentVelocity = Vector3.zero;
    

    private void Start()
    {
        currentPosition = transform.position;
        //Debug.Log("1st Enable : " + Time.time);
        Debug.Log(gameObject.name + " : " + currentPosition);
    }

    private void FixedUpdate()
    {
       
        Vector3 frontSegPosition = positionProvider.GetContinuousPosition();
        Debug.Log(gameObject.name + " ***************** : " + currentPosition);
        Vector3 direction = (frontSegPosition - currentPosition).normalized;

        Vector3 desiredPosition = frontSegPosition - direction * 0.2f;

        currentPosition = Vector3.SmoothDamp(currentPosition, desiredPosition, ref currentVelocity, 0.05f, 3.0f);

        //transform.position = currentPosition;
        transform.position = ScreenWrap.Wrapping(currentPosition);

    }

    public Vector3 GetContinuousPosition()
    {
        return currentPosition;
    }

    public void InitializeSegement(GameObject newfrontSegment)
    {   

        frontSegment = newfrontSegment;
        positionProvider = frontSegment.GetComponent<IPositionProvider>();
        //
        //currentPosition = positionProvider?.GetContinuousPosition() ?? transform.position;

        Vector3 difference = (frontSegment.transform.position - transform.position).normalized;
        transform.position = frontSegment.transform.position - difference * 0.3f;
    }

}
