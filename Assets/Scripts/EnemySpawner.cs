using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;


public class EnemySpawner : MonoBehaviour
{
    public int maxEnemies;
    private int currentEnemies;
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 2f;
    public float spawnRadius = 30f;

    private Transform playerTransform;
    private NavMeshSurface navMeshSurface;

    private float spawnTimer;

    void Start()
    {
        spawnTimer = spawnInterval;
        navMeshSurface = FindObjectOfType<NavMeshSurface>();
        currentEnemies = 0;
        gestionVidas.onDeadEnemy += EnemigoMuerto;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f && currentEnemies < maxEnemies)
        {
            currentEnemies++;
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