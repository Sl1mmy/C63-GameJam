using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfxonclick : MonoBehaviour
{
    public GameObject vfxPrefab; // Le prefab du VFX � jouer
    public float vfxLifetime = 1.0f; // Dur�e de vie du VFX en secondes

    private GameObject currentVFXInstance;

    private void Update()
    {
        // V�rifie si le bouton gauche de la souris est cliqu�
        if (Input.GetMouseButtonDown(0))
        {
            // R�cup�re la position du clic de la souris
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = 0; // Assure que la position z est correcte

            // Instancie le VFX � la position du clic
            currentVFXInstance = Instantiate(vfxPrefab, clickPosition, Quaternion.identity);

            Destroy(currentVFXInstance, 2f);

            // D�marre la coroutine pour d�truire le VFX apr�s un certain d�lai
            StartCoroutine(DestroyVFX(currentVFXInstance, vfxLifetime));
        }
    }

    // Coroutine pour d�truire le VFX apr�s un certain d�lai
    private IEnumerator DestroyVFX(GameObject vfxInstance, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(vfxInstance);
    }
}
