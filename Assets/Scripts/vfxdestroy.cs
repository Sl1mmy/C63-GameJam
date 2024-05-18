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
        // V�rifie si l'objet avec lequel on collisionne a le tag "Player"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 position = new Vector3(x, y, 0);

            // Instancie le VFX � la position du clic
            currentVFXInstance = Instantiate(vfxPrefab, position, Quaternion.identity);

            // D�truire cet objet
            Destroy(gameObject);
        }
    }
}
