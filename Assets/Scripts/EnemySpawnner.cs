using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnner : MonoBehaviour
{
    public GameObject prefab; // Spawn edilecek objenin prefabý

    public float spawnTime = 2f;
    private float passingTime = 0f;

    public Transform[] enemySpawnPoints;

    void Update()
    {
        // Belirli aralýklarla spawn iþlemi
        passingTime += Time.deltaTime;
        if (passingTime >= spawnTime)
        {
            SpawnObject();
            passingTime = 0.0f; // Süreyi sýfýrlayarak tekrar saymayý baþlat
        }
    }
    void SpawnObject()
    {
        int randomNoktaIndex = Random.Range(0, enemySpawnPoints.Length);
        Transform spawnPoint = enemySpawnPoints[randomNoktaIndex];

        // Seçilen noktada objeyi spawn et
        Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
}
