using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLineOfSight : MonoBehaviour
{
    public Transform player;
    public float raycastDistance = 10f;
    public LayerMask playerLayer;
    [Space(10)]
    public float chaseSpeed = 5f;
    public float jumpForce = 10f;
    [Space(5)]
    public float distanceBeforeCatchup = 12f;
    public float catchupSpeed = 20f;
    [Space(10)]
    public float groundCheckDistance = 0.1f;
    public bool isFly = false;

    private float newChaseSpeed;
    private bool isChasing = false;
    private bool chase = false;
    private bool isFacingRight = true;

    private Vector3 horizontal;

    private Rigidbody2D rb;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if the player is within line of sight
        if (HasLineOfSight())
        {
            // Play animation when the player is detected
            if (!isFly) { animator.SetBool("Awake", true); }
            raycastDistance = 10000f;
            isChasing = true;
        }

        if (isChasing && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            chase = true;
        }
        if (isChasing && isFly)
        {
            chase = true;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (chase)
        {
            if (!isFly) { animator.SetFloat("SpeedX", Mathf.Abs(horizontal.x)); }
            ChasePlayer();
        }
    }

    private bool HasLineOfSight()
    {
        Vector3 fixedPos = new Vector3(transform.position.x, transform.position.y - 3f, transform.position.z);
        // Create a raycast from the enemy towards the player
        RaycastHit2D hit = Physics2D.Raycast(fixedPos, (player.position - fixedPos).normalized, raycastDistance, playerLayer);

        // Check if the raycast hits the player
        if (hit.collider != null && hit.collider.gameObject.layer == player.gameObject.layer)
        {
            Debug.DrawLine(fixedPos, hit.point, Color.red);
            return true;
        }
        else
        {
            Debug.DrawLine(fixedPos, fixedPos + (player.position - fixedPos).normalized * raycastDistance, Color.green);
            return false;
        }
    }

    private void ChasePlayer()
    {

        // Increase chase speed if the distance exceeds a certain threshold
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > distanceBeforeCatchup) // Adjust this threshold value as needed
        {
            newChaseSpeed = catchupSpeed; // Set the increased chase speed
        }
        else
        {
            newChaseSpeed = chaseSpeed; // Set the default chase speed
        }

        if (isFly)
        {
            horizontal = (player.position - transform.position).normalized;
            rb.velocity = new Vector2(horizontal.x * newChaseSpeed, horizontal.y * newChaseSpeed);
        }
        else
        {
            horizontal = new Vector3(player.position.x - transform.position.x, 0f, 0f).normalized;
            rb.velocity = new Vector2(horizontal.x * newChaseSpeed, rb.velocity.y);
        }
    }

    private void Flip()
    {
        if (isFly)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
        else
        {
            if (isFacingRight && horizontal.x < 0f || !isFacingRight && horizontal.x > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
    }
}
