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
        Vector3 pos = this.transform.position;

        for (int i = BodyParts.Count - 1; i > 0; i--)
        {
            Debug.Log("Spawn        :       " + i);   // checkinh the spawn number number of loops run
            pos = new Vector3(BodyParts[i].transform.position.x, BodyParts[i].transform.position.y, 0);
            break;
        }

        GameObject bodyPart = Instantiate(GameAssets.Instance.snakeBodyPrefab, pos, Quaternion.identity);
        bodyParts.Add(bodyPart);
    }
}
