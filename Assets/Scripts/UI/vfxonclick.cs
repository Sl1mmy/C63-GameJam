using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfxonclick : MonoBehaviour
{
    public GameObject vfxPrefab; // Le prefab du VFX à jouer
    public float vfxLifetime = 1.0f; // Durée de vie du VFX en secondes

    private GameObject currentVFXInstance;

    private void Update()
    {
        // Vérifie si le bouton gauche de la souris est cliqué
        if (Input.GetMouseButtonDown(0))
        {
            // Récupère la position du clic de la souris
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0; // Assure que la position z est correcte

            // Instancie le VFX à la position du clic
            currentVFXInstance = Instantiate(vfxPrefab, clickPosition, Quaternion.identity);

            Destroy(currentVFXInstance, 2f);

            // Démarre la coroutine pour détruire le VFX après un certain délai
            StartCoroutine(DestroyVFX(currentVFXInstance, vfxLifetime));
        }
    }

    // Coroutine pour détruire le VFX après un certain délai
    private IEnumerator DestroyVFX(GameObject vfxInstance, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(vfxInstance);
    }
}
