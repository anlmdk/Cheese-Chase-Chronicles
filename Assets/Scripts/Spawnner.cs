using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject prefab; // Spawn edilecek nesne
    //public GameObject [] lastSpawnedCheese;

    public Vector3 spawnAreaMin; // Nesnelerin spawn edileceði alanýn minimum koordinatlarý
    public Vector3 spawnAreaMax; // Nesnelerin spawn edileceði alanýn maksimum koordinatlarý
    public float spawnTime = 2.0f; // Nesneler arasýndaki spawn aralýðý (saniye)

    private float passingTime = 0.0f;

    void Update()
    {
        // Eðer son spawn edilen nesne destroy edildiyse yeni bir nesne spawn et
        //if (lastSpawnedCheese == null)
        //{
        //    SpawnNesne();
        //}

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

        // Rastgele bir konum üretin
        Vector3 randomRange = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        // Nesneyi spawn edin
        Instantiate(prefab, randomRange, Quaternion.identity);
    }
}
