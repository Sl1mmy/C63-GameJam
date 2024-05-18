using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight = true;
    private bool isGrounded = false;

    [Header("Player Movement")]
    public float speed = 8f;
    public float jumpingPower = 16f;

    [Header("Ground Checking")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Fall Height")]
    public float fallHeightThreshold = 5f; // Adjust as needed
    private float previousYPosition;

    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("Jump", true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        animator.SetFloat("SpeedX", Mathf.Abs(horizontal * speed));
        animator.SetFloat("SpeedY", rb.velocity.y);

        Flip();

        CheckFallHeight();
    }

    private void FixedUpdate()
    {
        CheckGrounded();
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        animator.SetBool("Jump", !isGrounded);
    }

    private void CheckFallHeight()
    {
        if (!isGrounded && rb.velocity.y <= 0f)
        {
            // Player is falling
            float currentYPosition = transform.position.y;

            // Check if the current position is lower than the apex of the jump
            if (currentYPosition > previousYPosition)
            {
                // Update the apex position
                previousYPosition = currentYPosition;
            }
            else
            {
                // Calculate the fall height from the apex to the ground
                float fallHeight = previousYPosition - currentYPosition;
                animator.SetFloat("FallHeight", Mathf.Abs(fallHeight));
            }
        }
        else
        {
            // Reset the apex position if the player is grounded or jumping upwards
            previousYPosition = transform.position.y;
        }
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
