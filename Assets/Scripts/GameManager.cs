using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject snake1;
    public GameObject snake2;


    private void Start()
    {
        if (Lobby.isSecondSnakeSpawn)
        {
            snake1 = Instantiate(snake1, new Vector3 (-2,1,0), Quaternion.identity);
            snake2 = Instantiate(snake2, new Vector3(2, -1, 0), Quaternion.identity);
        }
        else
        {
            snake1 = Instantiate(snake1, new Vector3 (-2,1,0), Quaternion.identity);
        }

        SoundManager.Instance.SnakeRattleMusic(Sounds.SnakeRattle);

    }

}
