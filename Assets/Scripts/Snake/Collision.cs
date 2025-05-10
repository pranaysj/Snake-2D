using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Snake snake;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CollectableFood>() != null)
        {
            //If we write this line outside the 'if statement' then it will error whenever snake collide with non-Collectvael container
            FoodItemSO collected = collision.gameObject.GetComponent<CollectableFood>().collectedData;

            ScoreManager.Instance.FoodType(collected, this.gameObject);

            Destroy(collision.gameObject);

            //SPAWN SNAKE

        }

        if (collision.gameObject.GetComponent<CollectablePowerUp>() != null)
        {
            //If we write this line outside the 'if statement' then it will error whenever snake collide with non-Collectvael container
            PowerUpSO collected = collision.gameObject.GetComponent<CollectablePowerUp>().collectedData;

            PowerUpManager.Instance.PowerType(collected);

            Destroy(collision.gameObject);
        }

        SoundManager.Instance.ItemCollectSound(Sounds.ItemCollect);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SecondSnakeHead") || collision.gameObject.CompareTag("FirstSnakeHead"))
        {
            GameOverManager.Instance.DrawCondition();
        }
    }


}



