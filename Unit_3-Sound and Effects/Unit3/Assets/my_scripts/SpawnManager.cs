using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPosition;
    public GameObject spawnPrefab;
    private PlayerController controllerScript;

    private float spawnDelay = 2.0f;
    private float spawnInterval = 1.3f;
    // Start is called before the first frame update
    void Start()
    {
        controllerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        if (spawnPosition == Vector3.zero)
        {
            spawnPosition = transform.position;
        }

        InvokeRepeating("Spawn",spawnDelay,spawnInterval);
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        if (controllerScript.gameOver == false)
        {
            Instantiate(spawnPrefab, spawnPosition, spawnPrefab.transform.rotation);
        }
       
    }    
}

