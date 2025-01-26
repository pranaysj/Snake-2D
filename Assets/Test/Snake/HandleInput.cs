using UnityEngine;

public class HandleInput
{
    public enum InputType
    {
        WASD,
        ArrowKeys
    }

    public InputType type;

    public static bool lastInput = false;


    public void GetInput()
    {
        lastInput = !lastInput;
        type = lastInput ? InputType.WASD : InputType.ArrowKeys;
    }

    public Vector3 InputButton(Vector3 SnakeDirection)
    {
        if (type == InputType.WASD)
        {
            if (Input.GetKey(KeyCode.W) && SnakeDirection != Vector3.down) SnakeDirection = Vector3.up;
            else if (Input.GetKey(KeyCode.S) && SnakeDirection != Vector3.up) SnakeDirection = Vector3.down;
            else if (Input.GetKey(KeyCode.A) && SnakeDirection != Vector3.right) SnakeDirection = Vector3.left;
            else if (Input.GetKey(KeyCode.D) && SnakeDirection != Vector3.left) SnakeDirection = Vector3.right;
        }
        else if (type == InputType.ArrowKeys)
        {
            if (Input.GetKey(KeyCode.UpArrow) && SnakeDirection != Vector3.down) SnakeDirection = Vector3.up;
            else if (Input.GetKey(KeyCode.DownArrow) && SnakeDirection != Vector3.up) SnakeDirection = Vector3.down;
            else if (Input.GetKey(KeyCode.LeftArrow) && SnakeDirection != Vector3.right) SnakeDirection = Vector3.left;
            else if (Input.GetKey(KeyCode.RightArrow) && SnakeDirection != Vector3.left) SnakeDirection = Vector3.right;
        }
        return SnakeDirection;

    }
}
