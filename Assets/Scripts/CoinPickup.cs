using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public CoinCounter coinCounter;

    public GameObject vfxPrefab;

    private GameObject vfxInstance;

    private void Start()
    {
        Vector3 rotation = new Vector3(-71.78f, 0, 0);
        vfxInstance = Instantiate(vfxPrefab, transform.position, Quaternion.Euler(rotation));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collides with the coin
        if (collision.CompareTag("Player"))
        {
            // Increment the coin counter
            coinCounter.IncrementCoinCount();

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
                }
            }
            Destroy(vfxInstance);

            // Destroy the coin object
            Destroy(gameObject);
        }
    }
}
