using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.FilePathAttribute;
using UnityEngine.UIElements;

public class DestructableTile : MonoBehaviour
{
    private Tilemap destructableTilemap;
    Vector3 hitPosition = Vector3.zero;
    public GameObject vfxPrefab;

    private void Start()
    {
        destructableTilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            hitPosition = Vector3.zero;

            foreach(ContactPoint2D hit in collision.contacts)
            {
                hitPosition.x = hit.point.x + 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y + 0.01f * hit.normal.y;
                destructableTilemap.SetTile(destructableTilemap.WorldToCell(hitPosition), null);
                Vector3 rotation = new Vector3(71.78f, 0, 0);
                GameObject vfxInstance = Instantiate(vfxPrefab, hitPosition, Quaternion.Euler(rotation));

                // Détruire le VFX après 2 secondes
                Destroy(vfxInstance, 2f);
            }
        }
    }

    private void Update()
    {
        Debug.DrawLine(hitPosition - Vector3.right * 0.1f, hitPosition + Vector3.right * 0.1f, Color.red);
        Debug.DrawLine(hitPosition - Vector3.up * 0.1f, hitPosition + Vector3.up * 0.1f, Color.red);
        Debug.DrawLine(hitPosition - Vector3.forward * 0.1f, hitPosition + Vector3.forward * 0.1f, Color.red);
    }
}
