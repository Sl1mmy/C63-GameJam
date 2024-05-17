using System.Collections;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    public float speed = 5f; // Vitesse de d�placement du joueur
    public float resetPosX = -22f; // Position de r�initialisation sur l'axe X

    private bool isRunning = true;
    public Transform enemy;

    private Animator animator;

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
            // D�placer le joueur vers la droite
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            animator.SetBool("Jump", false);
            animator.SetFloat("SpeedX", speed);

            // V�rifier si le joueur est encore � l'�cran
            if (transform.position.x > 24f)
            {
                // Revenir � la position de d�part
                transform.position = new Vector3(0.47003442f, -14.5900002f, 0);
                enemy.position = new Vector3(0.47003442f, -14.5900002f, 0);
                yield return new WaitForSeconds(0.5f);
                transform.position = new Vector3(-22.2299995f, -1.41999996f, 0);
                enemy.position = new Vector3(-26.2199993f, 2.68000007f, 0);
            }



            yield return null;
        }
    }
}
