using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineOfSight : MonoBehaviour
{
    public Transform player;
    private Animator animator;
    public float raycastDistance = 10f;
    public LayerMask playerLayer;
    [Space(5)]
    public float chaseSpeed = 5f;

    private bool isChasing = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the player is within line of sight
        if (HasLineOfSight())
        {
            // Play animation when the player is detected
            animator.SetBool("Awake", true);
            raycastDistance = 10000f;
            isChasing = true;
        }

        if (isChasing && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            ChasePlayer();
        }
    }

    private bool HasLineOfSight()
    {
        // Create a raycast from the enemy towards the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.position - transform.position).normalized, raycastDistance, playerLayer);

        // Check if the raycast hits the player
        if (hit.collider != null && hit.collider.gameObject.layer == player.gameObject.layer)
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            return true;
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + (player.position - transform.position).normalized * raycastDistance, Color.green);
            return false;
        }
    }

    private void ChasePlayer()
    {
        // Calculate direction to move towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Move towards the player
        transform.Translate(direction * chaseSpeed * Time.deltaTime);
    }
}
