using UnityEngine;

public static class ScreenWrap 
{

    private static Vector3 screenBound;
    private static Vector3 screenMinimum;

    public static Vector3 ScreenBound
    {
        get { return screenBound; }
        set { screenBound = value; }
    }

    public static Vector3 ScreenMinimum
    {
        get { return screenMinimum; }
        set { screenMinimum = value; }
    }

    public static void ScreenBoundary()
    {
        Camera mainCamera = Camera.main;

        ScreenBound = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        ScreenMinimum = mainCamera.ScreenToWorldPoint(new Vector2(0.0f, 0.0f));


    }

    public static Vector3 Wrapping(Vector3 position)
    {
        ////up and down
        //if (position.y > ScreenBound.y)
        //{
        //    position.y = -ScreenBound.y;

        //}
        //else if (position.y < -ScreenBound.y)
        //{
        //    position.y = ScreenBound.y;
        //}

        ////Left and  Right Wrap
        //if (position.x > ScreenBound.x)
        //{
        //    position.x = -ScreenBound.x;
        //}
        //else if (position.x < -ScreenBound.x)
        //{
        //    position.x = ScreenBound.x;
        //}

        //return position;

        return new Vector3(WrapAxis(position.x, ScreenBound.x), WrapAxis(position.y, ScreenBound.y), position.z);

    }

    private static float WrapAxis(float value, float bound)
    {
        float min = -bound;
        float max = bound;
        float range = max - min;
        if (value > max)
            return min + (value - max) % range;
        if (value < min)
            return max - (min - value) % range;
        return value;
    }

}
