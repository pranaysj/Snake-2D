using System.Collections;
using UnityEngine;

public class SnakeManager : MonoBehaviour 
{
    public Movement move = new Movement();
    public ScreenWrap screenWrap = new ScreenWrap();
    public Segment segment = new Segment();
    public HandleInput handleInput = new HandleInput();
}
