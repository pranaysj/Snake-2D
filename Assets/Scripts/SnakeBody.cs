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
        snakeMovement = GetComponent<SnakeMovement>();
        BodyParts.Add(this.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SpawnBodyPart();
    }
    private void SpawnBodyPart()
    {
        Vector3 pos = BodyParts[BodyParts.Count - 1].transform.position;


        var direction = snakeMovement.SnakeDirection;
        var spawnPosiotn = pos - (Vector3)direction * 0.3f;

        GameObject bodyPart = Instantiate(GameAssets.Instance.snakeBodyPrefab, spawnPosiotn, Quaternion.identity);
        bodyParts.Add(bodyPart);
    }
}
