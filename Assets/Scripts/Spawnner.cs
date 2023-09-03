using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject prefab; // Spawn edilecek nesne
    //public GameObject [] lastSpawnedCheese;

    public Vector3 spawnAreaMin; // Nesnelerin spawn edilece�i alan�n minimum koordinatlar�
    public Vector3 spawnAreaMax; // Nesnelerin spawn edilece�i alan�n maksimum koordinatlar�
    public float spawnTime = 2.0f; // Nesneler aras�ndaki spawn aral��� (saniye)

    private float passingTime = 0.0f;

    void Update()
    {
        // E�er son spawn edilen nesne destroy edildiyse yeni bir nesne spawn et
        //if (lastSpawnedCheese == null)
        //{
        //    SpawnNesne();
        //}

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

        // Rastgele bir konum �retin
        Vector3 randomRange = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        // Nesneyi spawn edin
        Instantiate(prefab, randomRange, Quaternion.identity);
    }
}
