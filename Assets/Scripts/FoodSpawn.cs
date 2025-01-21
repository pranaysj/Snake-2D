using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    private Vector3 screenBound;
    private Vector2 screenMinimum;
    private float offset = 0.5f;
    public List<GameObject> foodSpawnList = new List<GameObject>();
    private float spawnInterval = 2.0f;
    private float destoryInterval = 5.0f;
    private GameObject snakeHead;
    SnakeCollision snakecollision;
    private int foodCount = 0;

    void Start()
    {
        snakeHead = GameObject.Find("Snake");
        snakecollision = snakeHead.GetComponent<SnakeCollision>();

        Camera mainCamera = Camera.main;
        screenBound = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        screenMinimum = mainCamera.ScreenToWorldPoint(new Vector2(0.0f, 0.0f));

        StartCoroutine(SpawnFood());
    }

    private IEnumerator SpawnFood()
    {
        while (!snakecollision.snakeIsDeath)
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector3 randomPositioin = new Vector3(Random.Range(screenMinimum.x + offset, screenBound.x - offset), Random.Range(screenMinimum.y + offset, screenBound.y - offset), 0.0f);

            if (randomPositioin != snakeHead.transform.position)
            {
                GameObject foodClone = Instantiate(SelectFoodType(), randomPositioin, Quaternion.identity);

                foodSpawnList.Add(foodClone);

                yield return new WaitForSeconds(destoryInterval);

                if (foodSpawnList != null)
                {
                    for (int i = 0; i < foodSpawnList.Count; i++)
                    {
                        Destroy(foodSpawnList[i]);
                        foodSpawnList.Remove(foodSpawnList[i]);
                    }
                }   
            }
        }
    }

    private GameObject SelectFoodType()
    {
        foodCount++;
        GameObject foodType;

        switch (foodCount)
        {
            case 4: case 8: case 12: case 16:
                foodType = GameAssets.Instance.food[1];
                break;
            case 6: case 10: case 18: case 22:
                foodType = GameAssets.Instance.food[2]; 
                break;
            default:
                foodType = GameAssets.Instance.food[0]; 
                break;
        }

        if(foodCount > 25) foodCount = 0;

        return foodType;
    }
}
