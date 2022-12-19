using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour {

    // L/R movement vars
    public float speed;
    public float jumpForce;
    private float moveInput;

    // Rigidbody2D var
    private Rigidbody2D rb;

    // Jump movement vars
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;
    private int extraJumps;
    public int extraJumpsValue;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    
    // Fall speed modification vars
    public float fallMultiplier = 30f;
    public float lowJumpMultiplier = 27.5f;

    // End of vars

    void Start(){
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
	if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && extraJumps > 0){
            rb.velocity = Vector2.up * jumpForce;
            extraJumps --;
        }else if((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded == true && extraJumps == 0){
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
            jumpTimeCounter = jumpTime;
        }
        if(isGrounded == true){
            extraJumps = extraJumpsValue;
        }

       if((Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.W)) && isJumping == true){

            if(jumpTimeCounter > 0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
        }
        if((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        isJumping = false;
        
            // Modify falling speed
        if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)))
        {
            // Make the player fall faster
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }

    void FixedUpdate(){

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }
}
