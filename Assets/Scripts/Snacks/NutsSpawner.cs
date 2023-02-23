using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutsSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject nutsPrefab;

    [SerializeField]
    Transform nutsSpawnZone;

    [SerializeField]
    Transform arm;

    [SerializeField]
    private List<GameObject> nutsSpawnList = new List<GameObject>();


    void Start()
    {
        //Snack in einem zufälligen Intervall erstellen, wenn nicht bereits drei derselben Sorte existieren 
        float interval = Random.Range(1, 4);
        if (nutsSpawnList.Count < 3)
        {
            InvokeRepeating("SpawnNuts", 5f, interval);
        }
    }

    void Update()
    {
        for (var i = nutsSpawnList.Count - 1; i > -1; i--)
        {
            if (nutsSpawnList[i] == null)
                nutsSpawnList.RemoveAt(i);
        }

    }

    //Setzt den Spawnbereich fest und kontrolliert, ob der Arm darüber oder darunter ist
    public void SpawnNuts()
    {
        nutsSpawnZone.position = new Vector3(Random.Range(-9.51f, 4f), 1.65f, 0);
        float armPositionY = arm.position.y;
        if (armPositionY < nutsSpawnZone.position.y)
        {
            GameObject nuts = Instantiate(nutsPrefab, nutsSpawnZone.position, Quaternion.identity);
        nutsSpawnList.Add(nuts);
        }
    }
}
