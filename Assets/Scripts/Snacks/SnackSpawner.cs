using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnackSpawner : MonoBehaviour
{
    [Header("Was soll gespawnt werden?")]
    [SerializeField] private GameObject snackPrefab;
    [SerializeField] private int poolSize = 3;

    [Header("Referenzen")]
    [SerializeField] private Transform spawnZone;
    [SerializeField] private Transform arm;

    [Header("Spawn-Bereich (Koordinaten)")]
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float spawnY;

    [Header("Zeit-Einstellungen")]
    [SerializeField] private float startVerzoegerung = 1f; // Wie lange bis zum ersten Spawn?
    [SerializeField] private float minSpawnZeit = 1f;
    [SerializeField] private float maxSpawnZeit = 3f;

    private List<GameObject> snackPool = new List<GameObject>();

    void Start()
    {
        // 1. POOL AUFBAUEN
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(snackPrefab);
            obj.SetActive(false); // Unsichtbar machen
            snackPool.Add(obj);
        }

        // 2. Routine starten
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        // Wartet die initiale Zeit ab (z.B. 3 Sekunden bei Chips)
        yield return new WaitForSeconds(startVerzoegerung);

        while (true)
        {
            // Warte eine zufällige Zeit basierend auf deinen Inspector-Einstellungen
            yield return new WaitForSeconds(Random.Range(minSpawnZeit, maxSpawnZeit));

            SpawnSnack();
        }
    }

    public void SpawnSnack()
    {
        float armPositionY = arm.position.y;

        // Nutzt die eingestellten Koordinaten für X und Y
        spawnZone.position = new Vector3(Random.Range(minX, maxX), spawnY, 0);

        if (armPositionY < spawnZone.position.y)
        {
            GameObject snack = GetPooledSnack();

            if (snack != null)
            {
                snack.transform.position = spawnZone.position;
                snack.transform.rotation = Quaternion.identity;
                snack.SetActive(true);
            }
        }
    }

    private GameObject GetPooledSnack()
    {
        for (int i = 0; i < snackPool.Count; i++)
        {
            if (!snackPool[i].activeInHierarchy)
            {
                return snackPool[i];
            }
        }
        return null;
    }
}