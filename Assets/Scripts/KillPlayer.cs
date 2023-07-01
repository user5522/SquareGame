// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class KillPlayer : MonoBehaviour
// {
//     public Transform respawnPoint;
//     public float deathRange;
//     public CameraShake cameraShake;
//     public float intensity;
//     public float duration;

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.gameObject.CompareTag("DeathTrigger"))
//         {
//             cameraShake.SmoothShake(intensity, duration);

//             // Teleport the player to the respawn point
//             transform.position = respawnPoint.position;
//         }
//         else if (other.gameObject.CompareTag("Checkpoint"))
//         {
//             respawnPoint = other.transform;
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Transform respawnPoint;
    public float deathRange;
    public CameraShake cameraShake;
    public float intensity;
    public float duration;
    public GameObject squarePrefab;
    public Color[] colors;
    public float spawnChance = 0.25f;

    private SpriteRenderer spriteRenderer;
    private Color currentColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentColor = spriteRenderer.color;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathTrigger"))
        {
            cameraShake.SmoothShake(intensity, duration);

            if (Random.value <= spawnChance)
            {
                StartCoroutine(SpawnSquaresAndTeleport());
            }
            else
            {
                transform.position = respawnPoint.position;
            }
        }
        else if (other.gameObject.CompareTag("Checkpoint"))
        {
            respawnPoint = other.transform;
        }
    }

    IEnumerator SpawnSquaresAndTeleport()
    {
        SpawnSquares(transform.position);
        currentColor.a = 0f;
        spriteRenderer.color = currentColor;
        yield return new WaitForSeconds(.25f);
        currentColor.a = 1f;
        spriteRenderer.color = currentColor;
        transform.position = respawnPoint.position;
    }

    void SpawnSquares(Vector3 position)
    {
        int numSquares = Random.Range(3, 7);
        float spacing = 1f;

        List<Color> availableColors = new List<Color>(colors);
        List<Color> chosenColors = new List<Color>();

        for (int i = 0; i < numSquares; i++)
        {
            float offsetY = Random.Range(-(i * spacing), i * spacing);
            Vector3 spawnPosition = position + new Vector3(i * spacing, offsetY, 0f);

            GameObject square = Instantiate(squarePrefab, spawnPosition, Quaternion.identity);

            if (availableColors.Count == 0)
            {
                availableColors = new List<Color>(chosenColors);
                chosenColors.Clear();
            }

            int randomColorIndex = Random.Range(0, availableColors.Count);
            Color randomColor = availableColors[randomColorIndex];
            chosenColors.Add(randomColor);
            availableColors.RemoveAt(randomColorIndex);

            square.GetComponent<SpriteRenderer>().color = randomColor;
        }
    }
}
