using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject candyPrefab;

    [SerializeField]
    Transform candySpawnZone;

    [SerializeField]
    Transform arm;

    [SerializeField]
    private List<GameObject> candySpawnList = new List<GameObject>();

    void Start()
    {
        //Snack in einem zufälligen Intervall erstellen, wenn nicht bereits drei derselben Sorte existieren 
        float interval = Random.Range(1, 3);
        if (candySpawnList.Count < 3)
        {
            InvokeRepeating("SpawnCandy", 1f, interval);
        }
    }

    void Update()
    {
        for (var i = candySpawnList.Count - 1; i > -1; i--)
        {
            if (candySpawnList[i] == null)
                candySpawnList.RemoveAt(i);
        }
    }

    //Setzt den Spawnbereich fest und kontrolliert, ob der Arm darüber oder darunter ist
    public void SpawnCandy()
    {
        candySpawnZone.position = new Vector3(Random.Range(-10.48f, 4.98f), -3.7f, 0);
        float armPositionY = arm.position.y;
        if (armPositionY < candySpawnZone.position.y)
        {
            GameObject candy = Instantiate(candyPrefab, candySpawnZone.position, Quaternion.identity);
            candySpawnList.Add(candy);
        }

    }

}
