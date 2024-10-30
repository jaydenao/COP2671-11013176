using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRange;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {

        Instantiate(powerupPrefab,GenerateSpawnPosition(false),powerupPrefab.transform.rotation);  
        SpawnEnemyWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0){
            waveNumber++;
            Instantiate(powerupPrefab,GenerateSpawnPosition(false),powerupPrefab.transform.rotation);
            SpawnEnemyWave(waveNumber);
        }
    }

    private Vector3 GenerateSpawnPosition(bool inAir)
    {
        float spawnPosY = inAir ? 7 : 0;
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosz = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX,spawnPosY,spawnPosz);
        return spawnPos; 
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
             Instantiate(enemyPrefab,GenerateSpawnPosition(true),enemyPrefab.transform.rotation);
             
        }

        
    }
}
