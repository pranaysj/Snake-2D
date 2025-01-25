using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject snake1;
    public GameObject snake2;


    private void Start()
    {
        snake1 = Instantiate(snake1, new Vector3 (-3,0,0), Quaternion.identity);
    }


    //Instantiate the snake object with Input Type
}
