using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField] GameObject candyPrefab;
    [SerializeField] Transform candySpawnZone;
    [SerializeField] Transform arm;

    // Wie viele Süßigkeiten dürfen maximal GLEICHZEITIG auf dem Bildschirm sein?
    [SerializeField] int poolSize = 3;

    private List<GameObject> candyPool = new List<GameObject>();

    void Start()
    {
        // 1. POOL AUFBAUEN: Wir erstellen am Anfang alle nötigen Snacks und verstecken sie.
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(candyPrefab);
            obj.SetActive(false); // Unsichtbar machen
            candyPool.Add(obj);
        }

        // Wir starten den ersten Spawn-Vorgang
        StartCoroutine(SpawnRoutine());
    }

    // 2. DIE SPAWN-ROUTINE: Löst das Problem deines "falschen" Randoms
    IEnumerator SpawnRoutine()
    {
        while (true) // Läuft unendlich, solange der Spawner aktiv ist
        {
            // Warte eine zufällige Zeit
            yield return new WaitForSeconds(Random.Range(1f, 3f));

            SpawnCandy();
        }
    }

    public void SpawnCandy()
    {
        float armPositionY = arm.position.y;

        // Wir setzen die X-Position jedes Mal neu
        candySpawnZone.position = new Vector3(Random.Range(-10.48f, 4.98f), -3.7f, 0);

        if (armPositionY < candySpawnZone.position.y)
        {
            // 3. SNACK AUS DEM POOL HOLEN
            GameObject candy = GetPooledCandy();

            if (candy != null) // Wenn wir einen freien Snack gefunden haben
            {
                candy.transform.position = candySpawnZone.position;
                candy.transform.rotation = Quaternion.identity;
                candy.SetActive(true); // Sichtbar machen (das ist viel schneller als Instantiate!)
            }
        }
    }

    // Hilfsmethode: Sucht nach einem Snack im Pool, der gerade NICHT aktiv ist
    private GameObject GetPooledCandy()
    {
        for (int i = 0; i < candyPool.Count; i++)
        {
            if (!candyPool[i].activeInHierarchy)
            {
                return candyPool[i];
            }
        }
        return null; // Alle Snacks sind gerade im Bild
    }
}