using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float jumpForce = 2.25f;
    public float maxBounciness = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                float yVelocity = rb.velocity.y;
                float bounciness = Mathf.Min(Mathf.Abs(jumpForce * yVelocity), maxBounciness);
                Vector2 jumpDirection = new Vector2(0f, bounciness);
                rb.AddForce(jumpDirection, ForceMode2D.Impulse);
            }
        }
    }
}
