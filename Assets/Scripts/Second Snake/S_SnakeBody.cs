using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SnakeBody : MonoBehaviour
{
    private S_SnakeMovement snakeMovement;
    [SerializeField]private List<GameObject> bodyParts = new List<GameObject>();

    public List<GameObject> BodyParts
    {
        get { return bodyParts; }
        set { bodyParts = value; }
    }

    void Start()
    {
        SpriteRenderer snakeSprite = gameObject.AddComponent<SpriteRenderer>();
        snakeSprite.sprite = GameAssets.Instance.secondSnake;
        snakeSprite.color = Color.yellow;

        snakeMovement = GetComponent<S_SnakeMovement>();
        BodyParts.Add(this.gameObject);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) SpawnBodyPart();
    }
    public void SpawnBodyPart()
    {
        Vector3 pos = BodyParts[BodyParts.Count - 1].transform.position;

        var direction = snakeMovement.SnakeDirection;
        var spawnPosiotn = pos - (Vector3)direction * 0.3f;

        GameObject bodyPart = Instantiate(GameAssets.Instance.secondSnakeBodyPrefab, spawnPosiotn, Quaternion.identity);
        bodyParts.Add(bodyPart);

        //Remoev collider from 1st segment
        bodyParts[1].GetComponent<CircleCollider2D>().enabled = false;
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
