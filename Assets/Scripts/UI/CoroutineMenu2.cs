using System.Collections;
using UnityEngine;

public class CoroutineMenu2 : MonoBehaviour
{
    public Canvas night;
    public float duration = 5.0f;

    private void Start()
    {
        if (night.GetComponent<CanvasGroup>() == null)
        {
            night.gameObject.AddComponent<CanvasGroup>();
        }

        // Set initial alpha
        night.GetComponent<CanvasGroup>().alpha = 0f;

        StartCoroutine(FadeLoop());
    }

    private IEnumerator FadeLoop()
    {
        CanvasGroup canvasGroup = night.GetComponent<CanvasGroup>();

        while (true)
        {
            // Fade in
            yield return StartCoroutine(Fade(canvasGroup, 0f, 1f));
            yield return new WaitForSeconds(2.0f);

            // Fade out
            yield return StartCoroutine(Fade(canvasGroup, 1f, 0f));
            yield return new WaitForSeconds(2.0f);
        }
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
    }
}
