using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour{
    
public Transform respawnPoint;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeathTrigger"))
        {
            // Teleport the player to the respawn point
            transform.position = respawnPoint.position;
        }
    }
}
