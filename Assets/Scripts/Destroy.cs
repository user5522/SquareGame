using UnityEngine;

public class Destroy : MonoBehaviour
{
    public GameObject objectToDestroy;
    public bool shown = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectToDestroy.SetActive(!shown);
        }
    }
}
