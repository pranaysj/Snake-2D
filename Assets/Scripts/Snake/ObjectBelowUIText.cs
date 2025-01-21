using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectBelowUIText : MonoBehaviour
{

    private Vector3 screenBound;
    private Vector2 screenMinimum;

    [SerializeField] private float upHeight;
    [SerializeField] private float scoreTextWidth;
    [SerializeField] private float pauseButtonWidth;

    private SnakeBody snakeBody;
    private FoodSpawn foodList;
    private PowerUp powerList;

    public TextMeshProUGUI scoretext;
    public Image pauseButtonImage;

    private Color scoreTextColor;
    private Color pauseButtonColor;

    private void Start()
    {
        Camera mainCamera = Camera.main;
        screenBound = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        screenMinimum = mainCamera.ScreenToWorldPoint(new Vector2(0.0f, 0.0f));

        //scoretext = GetComponent<TextMeshProUGUI>();
        //pauseButtonImage = GetComponent<Image>();
        snakeBody = GameObject.Find("Snake").GetComponent<SnakeBody>();  
        foodList = GameObject.Find("Food").GetComponent<FoodSpawn>();   
        powerList = GameObject.Find("PowerUp").GetComponent<PowerUp>();

        upHeight = screenBound.y - 1.0f;

        scoreTextWidth = -screenBound.x + 2.0f;
        scoreTextColor = scoretext.color;

        pauseButtonWidth = screenBound.x - 0.5f;
        pauseButtonColor = pauseButtonImage.color;

    }

    

    void Update()
    {

        for (int i = snakeBody.BodyParts.Count-1; i > 0; i--)
        {
            if (snakeBody.BodyParts[i].transform.position.y > upHeight
                /*&& snakeBody.BodyParts[i].transform.position.x < scoreTextWidth*/)
            {
                scoreTextColor.a = 0.1f;
                pauseButtonColor.a = 0.1f;
                Debug.Log("YES");
            }
            else
            {
                scoreTextColor.a = 1.0f;
                pauseButtonColor.a = 1.0f;
            }

            scoretext.color = scoreTextColor;
            pauseButtonImage.color = pauseButtonColor;
            
            
        }


        for (int i = 0; i < foodList.foodSpawnList.Count; i++)
        {
            if (foodList.foodSpawnList[i].transform.position.y > upHeight
                && foodList.foodSpawnList[i].transform.position.x < scoreTextWidth)
            {
                scoreTextColor.a = 0.1f;
            }
            else
            {
                scoreTextColor.a = 1.0f;
            }

            scoretext.color = scoreTextColor;
        }

    } 
}
