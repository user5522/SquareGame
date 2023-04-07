using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float moveInput;

    [Header("Jump")]
    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private float checkRadius;

    [SerializeField]
    private int extraJumpsValue;

    [SerializeField]
    private float jumpTime;

    [Header("Fall Multiplier")]
    [SerializeField]
    private float fallMultiplier = 30f;

    [SerializeField]
    float lowJumpMultiplier = 27.5f;

    [Header("Speed Multiplier")]
    [SerializeField]
    private float speedMultiplier = 1f;

    [SerializeField]
    private float speedMultiplierTime = .25f;

    [SerializeField]
    private float speedMultCooldown = .25f;

    private bool isGrounded;
    private bool isJumping;
    private Rigidbody2D rb;
    private int extraJumps;
    private float jumpTimeCounter;
    private bool isSpeedBoosted = false;
    private float speedMultCooldownCounter = 0f;
    private float speedMultiplierCounter = 0f;

    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            speedMultiplier = 1f;
        }
        else if (
            (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            && isGrounded == true
            && extraJumps == 0
        )
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
            speedMultiplier = 1f;
        }
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            isJumping = false;
        }

        if ((Input.GetKeyDown(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.W)) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if ((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            isJumping = false;
            speedMultiplier = 1f;
        }

        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity +=
                    Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.velocity +=
                    Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
        if (
            (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            && (
                Input.GetKey(KeyCode.LeftArrow)
                || Input.GetKey(KeyCode.A)
                || Input.GetKey(KeyCode.RightArrow)
                || Input.GetKey(KeyCode.D)
            )
            && isGrounded == true
            && !isSpeedBoosted
        )
        {
            speedMultiplierCounter = speedMultiplierTime;
            speedMultiplier = 1.5f;
            isSpeedBoosted = true;
        }
        if (isSpeedBoosted)
        {
            if (speedMultCooldownCounter < speedMultCooldown)
            {
                speedMultCooldownCounter += Time.deltaTime;
            }
            else
            {
                speedMultiplier = 1f;
                isSpeedBoosted = false;
                speedMultCooldownCounter = 0f;
            }
        }
        if (speedMultiplierCounter > 0)
        {
            speedMultiplierCounter -= Time.deltaTime;
        }
        else
        {
            speedMultiplier = 1f;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            checkRadius,
            LayerMask.GetMask("Ground")
        );

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed * speedMultiplier, rb.velocity.y);
    }
}

// to do: make it so dashing in the air is only available once and dashing on the ground is available each .25s
