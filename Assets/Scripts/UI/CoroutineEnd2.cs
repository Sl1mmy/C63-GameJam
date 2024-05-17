using System.Collections;
using UnityEngine;

public class CoroutineEnd2 : MonoBehaviour
{
    public Transform crownImage; // L'image de la couronne à faire rebondir
    public float bounceHeight = 0.5f; // Hauteur du rebondissement
    public float bounceSpeed = 0.5f; // Vitesse du rebondissement

    private bool isBouncing = true; // Indique si l'image de la couronne doit continuer à rebondir

    void Start()
    {
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (isBouncing)
        {
            yield return StartCoroutine(BounceCrown());
        }
    }

    IEnumerator BounceCrown()
    {
        Vector3 originalPosition = crownImage.position;
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * bounceSpeed;
            float yOffset = Mathf.Sin(Mathf.PI * elapsedTime) * bounceHeight;
            crownImage.position = originalPosition + new Vector3(0, yOffset, 0);
            yield return null;
        }
    }

}
