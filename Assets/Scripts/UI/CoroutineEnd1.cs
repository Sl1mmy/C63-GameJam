using System.Collections;
using UnityEngine;

public class CoroutineEnd1 : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement du joueur
    public float resetPosX = -22f; // Position de réinitialisation sur l'axe X
    private int nbrSaut = 0;

    private bool isRunning = true;
    private Rigidbody2D rb;
    private Animator animator;
    public float jumpingPower = 45f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Run());
    }

    private void Update()
    {

    }

    private IEnumerator Run()
    {
        while (isRunning)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetFloat("SpeedX", speed);

            // Vérifier si le joueur est encore à l'écran
            if (transform.position.x > 24f)
            {
                gameObject.SetActive(false);
            }

            // Vérifier si le joueur est à la position de saut
            if (transform.position.x > -2.80f)
            {
                StartCoroutine(Jump());
            }
            yield return null;
        }
    }



    private IEnumerator Jump()
    {
        if (nbrSaut < 1)
        {
            Debug.Log("Le joueur saute !");
            rb.AddForce(Vector2.up * jumpingPower, ForceMode2D.Impulse);

            animator.SetBool("Jump", true);
            nbrSaut += 1;

            // Attendre un court instant avant de désactiver l'animation de saut
            yield return new WaitForSeconds(1.5f);
            animator.SetBool("Jump", false);
        }
    }

}
