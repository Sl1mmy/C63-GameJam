using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class vfxhover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject vfxPrefab;
    private GameObject currentVFXInstance;
    public float vfxLifetime = 1.0f;

    public void OnPointerEnter(PointerEventData evenData)
    {
        if (vfxPrefab != null)
        {
            Vector3 position = new Vector3(-0.389999986f, -1.01999998f, 0);
            Vector3 rotation = new Vector3(71.78f, 0, 0);

            currentVFXInstance = Instantiate(vfxPrefab, position, Quaternion.Euler(rotation));
        }
    }

    public void OnPointerExit(PointerEventData evenData)
    {
        if (vfxPrefab != null)
        {
            StartCoroutine(DestroyVFX(currentVFXInstance, vfxLifetime));
        }
    }

    private IEnumerator DestroyVFX(GameObject vfxInstance, float delay)
    {
        ParticleSystem particleSystem = vfxInstance.GetComponent<ParticleSystem>();

        if (particleSystem != null)
        {
            var mainModule = particleSystem.main;
            float startAlpha = mainModule.startColor.color.a;
            float currentAlpha = startAlpha;
            float fadeDuration = 1f;
            float timeElapsed = 0f;

            while (currentAlpha > 0)
            {
                timeElapsed += Time.deltaTime;
                currentAlpha = Mathf.Lerp(startAlpha, 0, timeElapsed / fadeDuration);
                mainModule.startColor = new Color(mainModule.startColor.color.r, mainModule.startColor.color.g, mainModule.startColor.color.b, currentAlpha);
                yield return null;
            }
        }

        yield return new WaitForSeconds(delay);
        Destroy(vfxInstance);
    }

}

