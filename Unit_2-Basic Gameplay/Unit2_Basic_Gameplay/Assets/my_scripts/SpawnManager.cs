using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public float spawnRangeX = 11f;
    public float spawnPosZ = 20f;

    private float startDelay = 2f;
    private float intervalRate = .75f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, intervalRate);
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void SpawnRandomAnimal()
    {
        int index = Random.Range(0, animalPrefabs.Length);
        GameObject animal = animalPrefabs[index];
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animal, spawnPos, animal.transform.rotation);
    }
}
