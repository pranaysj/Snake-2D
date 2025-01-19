using System;
using UnityEngine;
using TMPro;

public class ObjectBelowUIText : MonoBehaviour
{

    private Vector3 screenBound;
    private Vector2 screenMinimum;

    [SerializeField]private float rightWidth;
    [SerializeField] private float upHeight;

    private SnakeBody snakeBody;
    private TextMeshProUGUI text;
    private FoodSpawn foodList;
    private PowerUp powerList;

    private Color scoreTextColor;

    private void Start()
    {
        Camera mainCamera = Camera.main;
        screenBound = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        screenMinimum = mainCamera.ScreenToWorldPoint(new Vector2(0.0f, 0.0f));

        text = GetComponent<TextMeshProUGUI>();
        snakeBody = GameObject.Find("Snake").GetComponent<SnakeBody>();  
        foodList = GameObject.Find("Food").GetComponent<FoodSpawn>();   
        powerList = GameObject.Find("PowerUp").GetComponent<PowerUp>();

        upHeight = screenBound.y - 1.0f;
        rightWidth = -screenBound.x + 2.0f;

        scoreTextColor = text.color;

    }



    void Update()
    {

        for (int i = snakeBody.BodyParts.Count-1; i > 0; i--)
        {
            if (snakeBody.BodyParts[i].transform.position.y > upHeight
                && snakeBody.BodyParts[i].transform.position.x < rightWidth)
            {
                scoreTextColor.a = 0.1f;
            }
            else
            {
                scoreTextColor.a = 1.0f;
            }

            text.color = scoreTextColor;
        }


        for (int i = 0; i < foodList.foodSpawnList.Count; i++)
        {
            if (foodList.foodSpawnList[i].transform.position.y > upHeight
                && foodList.foodSpawnList[i].transform.position.x < rightWidth)
            {
                scoreTextColor.a = 0.1f;
            }
            else
            {
                scoreTextColor.a = 1.0f;
            }

            text.color = scoreTextColor;
        }

    } 
}
