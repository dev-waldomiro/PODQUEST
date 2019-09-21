using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	
	public float speed;
	public float jumpForce;
	public float fallMultiplier;
	public float lowJumpMultiplier;
	public float moveInput;
	public float checkRadius;

	private bool isGrounded;
	private bool hasJumped;

	public Transform groundCheck;
	public LayerMask whatIsGround;
	private Rigidbody2D rb;

    void Start() {

    	rb = GetComponent<Rigidbody2D>();
        
    }


    void Update() {
        
        if(isGrounded == true) {
        	hasJumped = false;
        }

    	if(Input.GetKeyDown(KeyCode.Space) && hasJumped == false && isGrounded == true) {
    		rb.velocity = Vector2.up * jumpForce;
    		hasJumped = true;
    	}

    	if(rb.velocity.y < 0) rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    	else if(rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
    }

    void FixedUpdate() {
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    	moveInput = Input.GetAxis("Horizontal");
    	rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }
}
