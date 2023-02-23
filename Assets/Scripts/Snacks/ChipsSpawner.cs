using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipsSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject chipsPrefab;

    [SerializeField]
    Transform chipsSpawnZone;

    [SerializeField]
    Transform arm;

    [SerializeField]
    private List<GameObject> chipsSpawnList = new List<GameObject>();

    void Start()
    {
        //Snack in einem zufälligen Intervall erstellen, wenn nicht bereits drei derselben Sorte existieren 
        float interval = Random.Range(1, 6);
        if (chipsSpawnList.Count < 3)
        {
            InvokeRepeating("SpawnChips", 3f, interval);
        }
    }

    void Update()
    {
        for (var i = chipsSpawnList.Count - 1; i > -1; i--)
        {
            if (chipsSpawnList[i] == null)
                chipsSpawnList.RemoveAt(i);
        }
    }

    //Setzt den Spawnbereich fest und kontrolliert, ob der Arm darüber oder darunter ist
    public void SpawnChips()
    {
        chipsSpawnZone.position = new Vector3(Random.Range(-9.45f, 3.78f), 6.99f, 0);
        float armPositionY = arm.position.y;
        if (armPositionY < chipsSpawnZone.position.y)
        {
            GameObject chips = Instantiate(chipsPrefab, chipsSpawnZone.position, Quaternion.identity);
        chipsSpawnList.Add(chips);
        }

    }
}
