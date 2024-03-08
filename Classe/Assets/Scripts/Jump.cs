using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    private float movementSpeed = 3.5f;

    [Header ("Jump System")]
    private float jumpTime = 0.35f;
    private float jumpPower = 12.0f;
    private float fallMultiplier = 1.5f;
    private float jumpMultiplier = 1.9f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    //Animator
    public Animator animator;
    Vector2 vecGravity;

    bool isJumping;
    float jumpCounter;

    [Header ("Wall Jump System")]
    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    private float wallSlidingSpeed = 1.6f;
    private float h;
    private float wallJumpDuration = 0.1f;
    private Vector2 wallJumpForce = new Vector2(9, 13);
    bool wallJumping;
    private static int countWallJumps;

    // Start is called before the first frame update
    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        if (isGrounded())
        {
            countWallJumps = 1;
        }
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;
        }
        else if (Input.GetButtonDown("Jump") && isSliding && countWallJumps != 0)
        {
            wallJumping = true;
            Invoke("StopWallJump", wallJumpDuration);
            countWallJumps--;
        }

        if(rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isJumping = false;

            float t = jumpCounter / jumpTime;
            float currentJumpM = jumpMultiplier;
            if(t > 0.5f)
            {
                currentJumpM = jumpMultiplier * (1 - t);
            }
            rb.velocity += vecGravity * currentJumpM * Time.deltaTime;
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpCounter = 0;

            if(rb.velocity.y > 0)
            {
                rb.velocity =new Vector2(rb.velocity.x, rb.velocity.y * 0.6f);
                animator.SetBool("Jump",wallJumping);
            }
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
        }
        isWallTouch = Physics2D.OverlapBox(wallCheck.position, new Vector2(0.07f, 0.54f), 0, groundLayer);

        if(isWallTouch && !isGrounded() && h != 0)
        {
            isSliding = true;
        }
        else
        {
            isSliding = false;
        }
    }

    private void FixedUpdate()
    {
        if(isSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if (wallJumping)
        {
            rb.velocity = new Vector2(-h * wallJumpForce.x, wallJumpForce.y);
        }
        else
        {
            rb.velocity = new Vector2(h * movementSpeed, rb.velocity.y);
        }
    }

    void StopWallJump()
    {
        wallJumping = false;
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCapsule(groundCheck.position, new Vector2(0.75f, 0.1f), CapsuleDirection2D.Horizontal, 0, groundLayer);
    }
}
