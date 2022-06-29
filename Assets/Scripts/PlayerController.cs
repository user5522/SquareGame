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

    //jump movement vars
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;
    private int extraJumps;
    public int extraJumpsValue;


    void Start(){
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
            rb.velocity = Vector2.up * jumpForce;
            extraJumps --;
        }else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true){
            rb.velocity = Vector2.up * jumpForce;
        }
        if(isGrounded == true){
            extraJumps = extraJumpsValue;
        }
    }

    void FixedUpdate(){

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }
}