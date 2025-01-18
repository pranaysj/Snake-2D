using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    private Vector3 screenBound;
    private Vector2 screenMinimum;
    private float offset = 0.5f;
    [SerializeField] private List<GameObject> spawnList = new List<GameObject>();
    private float spawnInterval = 2.0f;
    private float destoryInterval = 5.0f;
    private GameObject snakeHead;
    SnakeCollision snakecollision;
    private int powerCount = 0;

    void Start()
    {
        snakeHead = GameObject.Find("Snake");
        snakecollision = snakeHead.GetComponent<SnakeCollision>();

        Camera mainCamera = Camera.main;
        screenBound = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        screenMinimum = mainCamera.ScreenToWorldPoint(new Vector2(0.0f, 0.0f));

        StartCoroutine(SpawnApple());
    }

    private IEnumerator SpawnApple()
    {
        while (!snakecollision.snakeIsDeath)
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector3 randomPositioin = new Vector3(Random.Range(screenMinimum.x + offset, screenBound.x - offset), Random.Range(screenMinimum.y + offset, screenBound.y - offset), 0.0f);

            if (randomPositioin != snakeHead.transform.position)
            {
                GameObject appleClone = Instantiate(SelectAppleType(), randomPositioin, Quaternion.identity);

                spawnList.Add(appleClone);

                yield return new WaitForSeconds(destoryInterval);

                if (spawnList != null)
                {
                    for (int i = 0; i < spawnList.Count; i++)
                    {
                        Destroy(spawnList[i]);
                        spawnList.Remove(spawnList[i]);
                    }
                }   
            }
        }
    }

    private GameObject SelectAppleType()
    {
        powerCount++;
        GameObject appleType;

        switch (powerCount)
        {
            case 4: case 8: case 12: case 16:
                appleType = GameAssets.Instance.apple[1];
                break;
            case 6: case 10: case 18: case 22:
                appleType= GameAssets.Instance.apple[2]; 
                break;
            default:
                appleType = GameAssets.Instance.apple[0]; 
                break;
        }

        if(powerCount > 25) powerCount = 0;

        return appleType;
    }
}
