using System.Collections;
using UnityEngine;

public class Coroutine2 : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement du joueur
    public float resetPosX = -22f; // Position de réinitialisation sur l'axe X

    private bool isRunning = true;
    private Rigidbody2D rb;
    private Animator animator;
    public float jumpingPower = 16f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Run());
    }

    private void Update()
    {

    }

    private IEnumerator Run()
    {
        while (isRunning)
        {
            // Déplacer le joueur vers la droite
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetBool("Jump", false);
            animator.SetFloat("SpeedX", speed);

            // Vérifier si le joueur est encore à l'écran
            if (transform.position.x > 24f)
            {
                gameObject.SetActive(false);
            }

            yield return null;
        }
    }

    private void Jump()
    {
        // Activer l'animation de saut
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        animator.SetBool("Jump", true);
    }
}
