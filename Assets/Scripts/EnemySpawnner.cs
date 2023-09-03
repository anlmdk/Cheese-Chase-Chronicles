using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public GameObject prefab; // Spawn edilecek objenin prefab�

    public float spawnTime = 2f;
    private float passingTime = 0f;

    public Transform[] enemySpawnPoints;

    void Update()
    {
        // Belirli aral�klarla spawn i�lemi
        passingTime += Time.deltaTime;
        if (passingTime >= spawnTime)
        {
            SpawnObject();
            passingTime = 0.0f; // S�reyi s�f�rlayarak tekrar saymay� ba�lat
        }
    }
    void SpawnObject()
    {
        int randomNoktaIndex = Random.Range(0, enemySpawnPoints.Length);
        Transform spawnPoint = enemySpawnPoints[randomNoktaIndex];

        // Se�ilen noktada objeyi spawn et
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
