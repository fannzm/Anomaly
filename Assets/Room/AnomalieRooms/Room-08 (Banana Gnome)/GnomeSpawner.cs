using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnomeSpawner : MonoBehaviour
{
    public GameObject gnomePrefab;  // dein Bananen-Gnom Prefab
    public Transform spawnPoint;     // wo der Gnom erscheinen soll

    private bool hasSpawned = false; // verhindert mehrfaches Spawnen

    void OnTriggerEnter(Collider other)
    {
        if (!hasSpawned && other.CompareTag("Player"))
        {
            if (gnomePrefab != null && spawnPoint != null)
            {
                var newGnome = Instantiate(gnomePrefab, spawnPoint.position, spawnPoint.rotation);
                hasSpawned = true; // nur einmal spawnen

                newGnome.transform.parent = gameObject.transform;

            }
        }
    }
}

