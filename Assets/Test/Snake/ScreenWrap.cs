using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ScreenWrap 
{

    private Vector3 screenBound;
    private Vector3 screenMinimum;

    public Vector3 ScreenBound
    {
        get { return screenBound; }
        set { screenBound = value; }
    }

    public Vector3 ScreenMinimum
    {
        get { return screenMinimum; }
        set { screenMinimum = value; }
    }

    public void ScreenBoundary()
    {
        Camera mainCamera = Camera.main;

        ScreenBound = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        ScreenMinimum = mainCamera.ScreenToWorldPoint(new Vector2(0.0f, 0.0f));

    }

    public Vector3 Wrapping(Vector3 position)
    {
        //up and down
        if (position.y > screenBound.y)
        {
            position.y = -screenBound.y;

        }
        else if (position.y < -screenBound.y)
        {
            position.y = screenBound.y;
        }

        //Left and  Right Wrap
        if (position.x > screenBound.x)
        {
            position.x = -screenBound.x;
        }
        else if (position.x < -screenBound.x)
        {
            position.x = screenBound.x;
        }

        return position;
    }

    //private void Start()
    //{
    //    ScreenBoundary();
    //}

    //public void Update()
    //{
    //    transform.position = Wrapping(transform.position);
    //}
}
