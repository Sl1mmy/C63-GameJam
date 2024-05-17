using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class vfxhover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject vfxPrefab;
    private GameObject currentVFXInstance;
    public float vfxLifetime = 1.0f;

    // This method is called when the pointer enters the button's area
    public void OnPointerEnter(PointerEventData evenData)
    {
        if (vfxPrefab != null)
        {
            Vector3 position = new Vector3(-0.389999986f, -1.01999998f, 0);
            Vector3 rotation = new Vector3(71.78f, 0, 0);

            // Instancie le VFX à la position du clic
            currentVFXInstance = Instantiate(vfxPrefab, position, Quaternion.Euler(rotation));
        }
    }

    // This method is called when the pointer exits the button's area
    public void OnPointerExit(PointerEventData evenData)
    {
        if (vfxPrefab != null)
        {
            StartCoroutine(DestroyVFX(currentVFXInstance, vfxLifetime));
        }
    }

    private IEnumerator DestroyVFX(GameObject vfxInstance, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(vfxInstance);
    }
}

