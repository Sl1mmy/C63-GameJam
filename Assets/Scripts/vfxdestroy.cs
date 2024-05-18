using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vfxdestroy : MonoBehaviour
{
    public GameObject vfxPrefab;

    private GameObject currentVFXInstance;

    public float x;
    public float y;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifie si l'objet avec lequel on collisionne a le tag "Player"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 position = new Vector3(x, y, 0);

            // Instancie le VFX à la position du clic
            currentVFXInstance = Instantiate(vfxPrefab, position, Quaternion.identity);

            // Détruire cet objet
            Destroy(gameObject);
        }
    }
}
