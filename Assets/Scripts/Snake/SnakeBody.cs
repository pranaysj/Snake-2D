using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBody : MonoBehaviour
{
    private SnakeMovement snakeMovement;
    [SerializeField]private List<GameObject> bodyParts = new List<GameObject>();

    public List<GameObject> BodyParts
    {
        get { return bodyParts; }
        set { bodyParts = value; }
    }

    void Start()
    {
        SpriteRenderer snakeSprite = gameObject.AddComponent<SpriteRenderer>();
        snakeSprite.sprite = GameAssets.Instance.snake;
        snakeSprite.color = Color.green;

        snakeMovement = GetComponent<SnakeMovement>();
        BodyParts.Add(this.gameObject);
    }

    public void SpawnBodyPart()
    {
        Vector3 pos = BodyParts[BodyParts.Count - 1].transform.position;

        var direction = snakeMovement.SnakeDirection;
        var spawnPosiotn = pos - (Vector3)direction * 0.3f;

        GameObject bodyPart = Instantiate(GameAssets.Instance.snakeBodyPrefab, spawnPosiotn, Quaternion.identity);
        bodyParts.Add(bodyPart);

        //Remoev collider from 1st segment
        bodyParts[1].GetComponent<BoxCollider2D>().enabled = false;
    }

    public void RemoveBodyPart()
    {
        GameObject segment = BodyParts[BodyParts.Count - 1];

        if (BodyParts.Count > 3)
        {
            Destroy(segment);
            BodyParts.Remove(segment);
        }
    }
}
