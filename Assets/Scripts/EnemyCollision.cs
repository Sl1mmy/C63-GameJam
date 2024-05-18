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
            playerMovement.enabled = false;
            enemyMovement.enabled = false;

            Invoke("ReloadScene", 0f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        playerMovement.enabled = true;
        enemyMovement.enabled = true;
    }
}

