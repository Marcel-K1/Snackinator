using System.Collections;
using UnityEngine;

public class MenuRainSpawner : MonoBehaviour
{
    [Header("Welche Snacks sollen fallen?")]
    [SerializeField] private GameObject[] menuSnackPrefabs;

    [Header("Spawn Bereich (oben im Bild)")]
    [SerializeField] private float minX = -2.5f;
    [SerializeField] private float maxX = 2.5f;
    [SerializeField] private float spawnY = 6f;

    [Header("Zeit & Limits")]
    [SerializeField] private float startIntervall = 1.5f;
    [SerializeField] private float minIntervall = 0.2f; // Wie schnell darf es maximal werden?
    [SerializeField] private int maxSnacks = 50;       // Stoppt den Regen, bevor das Spiel ruckelt

    private int currentSnackCount = 0;

    void Start()
    {
        StartCoroutine(RainRoutine());
    }

    IEnumerator RainRoutine()
    {
        float aktuellesIntervall = startIntervall;

        while (currentSnackCount < maxSnacks)
        {
            // Einen zufälligen Snack aus dem Array (Liste) aussuchen
            int randomIndex = Random.Range(0, menuSnackPrefabs.Length);
            GameObject prefabToSpawn = menuSnackPrefabs[randomIndex];

            // Eine zufällige X-Position berechnen
            Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), spawnY, 0);

            // Eine zufällige Start-Drehung (Rotation) sieht natürlicher aus
            Quaternion randomRotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));

            // Snack erschaffen
            Instantiate(prefabToSpawn, spawnPos, randomRotation);

            currentSnackCount++;

            // Warten, bevor der nächste fällt
            yield return new WaitForSeconds(aktuellesIntervall);

            // Das Intervall ein bisschen verkleinern, damit es immer schneller regnet
            if (aktuellesIntervall > minIntervall)
            {
                aktuellesIntervall -= 0.05f;
            }
        }
    }
}
