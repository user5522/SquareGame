using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Animator animator;
    public new ParticleSystem particleSystem;

    private bool hasCollided = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !hasCollided)
        {
            other.GetComponent<KillPlayer>().respawnPoint = transform;
            animator.SetTrigger("CheckpointReached");
            particleSystem.Play();
            hasCollided = true;
        }
    }
}
