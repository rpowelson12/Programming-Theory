using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    
    private float startTime = 1;
    private float repeatRate = 1;
    private float enemyMax = 5;
    private int spawnRange = 30;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startTime, repeatRate);
        
        
        //Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        //GameObject enemy;

        Instantiate(enemyPrefab, GenerateRandomPosition(), enemyPrefab.transform.rotation);

        //enemies.Add(enemy);
    }

    private Vector3 GenerateRandomPosition()
    {
        int spawnX = Random.Range(-spawnRange, spawnRange);
        int spawnZ = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnX, 1, spawnZ);

        return spawnPos;
    }
}
