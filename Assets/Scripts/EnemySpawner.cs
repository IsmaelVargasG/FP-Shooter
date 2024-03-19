using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;


public class EnemySpawner : MonoBehaviour
{
    public static int maxEnemies;
    private static int currentEnemies;
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 2f;
    public float spawnRadius = 30f;
    bool flag = false;


    private float spawnTimer;

    void Start()
    {
        maxEnemies = 20;
        spawnTimer = spawnInterval;
        currentEnemies = 0;
        gestionVidas.onDeadEnemy += EnemigoMuerto;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if(currentEnemies == maxEnemies){flag = true;}
        if (spawnTimer <= 0f && currentEnemies < maxEnemies)
        {
            if(flag == true){currentEnemies += 4;}
            else{currentEnemies++;}

            SpawnEnemy();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Vector3 randomOffset =  Random.insideUnitSphere * spawnRadius;
        randomOffset.y = 0f;
        Vector3 spawnPosition = transform.position + randomOffset;


        NavMeshHit hit;
        if (NavMesh.SamplePosition(spawnPosition, out hit, spawnRadius, NavMesh.AllAreas))
        {
            spawnPosition = hit.position;
            Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Failed to find a valid spawn point within the NavMesh.");
        }
    }

    void EnemigoMuerto(){
        currentEnemies--;
    }
}