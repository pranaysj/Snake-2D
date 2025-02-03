using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Self Head
        if (collision.gameObject.GetComponent<Snake>() != null)
        {
            //CAll method with parameter of collision => In GameOveManager.cs
            GameOverManager.Instance.VictoryCondition(collision.gameObject);
            
        }

        //Othersnkae
    }
}
