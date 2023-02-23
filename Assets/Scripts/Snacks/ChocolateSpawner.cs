using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolateSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject chocolatePrefab;

    [SerializeField]
    Transform chocolateSpawnZone;

    [SerializeField]
    Transform arm;

    [SerializeField]
    private List<GameObject> chocolateSpawnList = new List<GameObject>();

    void Start()
    {
        //Snack in einem zufälligen Intervall erstellen, wenn nicht bereits drei derselben Sorte existieren 
        float interval = Random.Range(1, 7);
        if (chocolateSpawnList.Count < 3)
        {
            InvokeRepeating("SpawnChocolate", 2f, interval);
        }
    }

    void Update()
    {
        for (var i = chocolateSpawnList.Count - 1; i > -1; i--)
        {
            if (chocolateSpawnList[i] == null)
                chocolateSpawnList.RemoveAt(i);
        }
    }

    //Setzt den Spawnbereich fest und kontrolliert, ob der Arm darüber oder darunter ist
    public void SpawnChocolate()
    {
        chocolateSpawnZone.position = new Vector3(Random.Range(-10.3f, 4.98f), 12.4f, 0);
        float armPositionY = arm.position.y;
        if (armPositionY < chocolateSpawnZone.position.y)
        {
            GameObject chocolate = Instantiate(chocolatePrefab, chocolateSpawnZone.position, Quaternion.identity);
        chocolateSpawnList.Add(chocolate);
        }
    }
}
