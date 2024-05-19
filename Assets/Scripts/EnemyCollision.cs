using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public EnemyLineOfSight enemyMovement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerMovement != null) { playerMovement.enabled = false; }
            if (enemyMovement != null) { enemyMovement.enabled = false; }

            Invoke("ReloadScene", 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerMovement != null) { playerMovement.enabled = false; }
            if (enemyMovement != null) {  enemyMovement.enabled = false; }
            Invoke("ReloadScene", 0f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (playerMovement != null) { playerMovement.enabled = true; }
        if (enemyMovement != null) { enemyMovement.enabled = true; }
    }
}

