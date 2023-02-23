using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SodaSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject sodaPrefab;

    [SerializeField]
    Transform sodaSpawnZone;

    [SerializeField]
    Transform arm;

    [SerializeField]
    private List<GameObject> sodaSpawnList = new List<GameObject>();

    void Start()
    {
        //Snack in einem zufälligen Intervall erstellen, wenn nicht bereits drei derselben Sorte existieren 
        float interval = Random.Range(1, 5);
        if (sodaSpawnList.Count < 3)
        {
            InvokeRepeating("SpawnSoda", 3f, interval);
        }
    }

    void Update()
    {
        for (var i = sodaSpawnList.Count - 1; i > -1; i--)
        {
            if (sodaSpawnList[i] == null)
                sodaSpawnList.RemoveAt(i);
        }
    }


    //Setzt den Spawnbereich fest und kontrolliert, ob der Arm darüber oder darunter ist
    private void SpawnSoda()
    {
        sodaSpawnZone.position = new Vector3(Random.Range(-10.53f,5.08f),16.73f, 0);
        float armPositionY = arm.position.y;
        if (armPositionY < sodaSpawnZone.position.y)
        {
            GameObject soda = Instantiate(sodaPrefab,sodaSpawnZone.position,Quaternion.identity);
            sodaSpawnList.Add(soda);
        }
    }
}
