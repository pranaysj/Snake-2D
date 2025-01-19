using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Vector3 screenBound;
    private Vector2 screenMinimum;
    private float offset = 0.5f;

    [SerializeField] private List<GameObject> powerUpSpawnList = new List<GameObject>();
    private float spawnInterval = 8.0f;
    private float destoryInterval = 2.5f;
    private int powerCount = 0;

    private GameObject snakeHead;
    SnakeCollision snakecollision;

    void Start()
    {
        snakeHead = GameObject.Find("Snake");
        snakecollision = snakeHead.GetComponent<SnakeCollision>();

        Camera mainCamera = Camera.main;
        screenBound = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        screenMinimum = mainCamera.ScreenToWorldPoint(new Vector2(0.0f, 0.0f));

        StartCoroutine(SpawnpowerUp());
    }

    private IEnumerator SpawnpowerUp()
    {
        while (!snakecollision.snakeIsDeath)
        {
            float randomSpawnInterval = Random.Range(1.0f, spawnInterval);
            yield return new WaitForSeconds(randomSpawnInterval);

            Vector3 randomPositioin = new Vector3(Random.Range(screenMinimum.x + offset, screenBound.x - offset), Random.Range(screenMinimum.y + offset, screenBound.y - offset), 0.0f);

            if (randomPositioin != snakeHead.transform.position)
            {
                int randomType = Random.Range(0, 3);
                GameObject powerUpClone = Instantiate(SelectPowerType(randomType), randomPositioin, Quaternion.identity);

                powerUpSpawnList.Add(powerUpClone);

                yield return new WaitForSeconds(destoryInterval);

                if (powerUpSpawnList != null)
                {
                    for (int i = 0; i < powerUpSpawnList.Count; i++)
                    {
                        Destroy(powerUpSpawnList[i]);
                        powerUpSpawnList.Remove(powerUpSpawnList[i]);
                    }
                }
            }
        }
    }

    private GameObject SelectPowerType(int powerCount)
    {
        GameObject powerType;

        switch (powerCount)
        {
            case 0:
                powerType = GameAssets.Instance.powerUp[2];
                break;
            case 1:
                powerType = GameAssets.Instance.powerUp[2];
                break;
            default:
                powerType = GameAssets.Instance.powerUp[2];
                break;
        }

        return powerType;
    }
}
