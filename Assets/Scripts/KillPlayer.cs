using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Transform respawnPoint;
    public float deathRange;
    public CameraShake cameraShake;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathTrigger"))
        {
            cameraShake.shakeDuration = 0.75f;
            // Teleport the player to the respawn point
            transform.position = respawnPoint.position;
        }
    }
}
