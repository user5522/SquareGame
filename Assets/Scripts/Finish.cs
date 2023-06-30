using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public int targetScene;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "finish")
        {
            SceneManager.LoadScene(targetScene);
        }
    }
}
