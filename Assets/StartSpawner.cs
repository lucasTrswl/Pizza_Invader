using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawner : MonoBehaviour
{
    public GameObject[] stars;
    private GameObject[] currents;
    private float spawnTimer = 0.5f;
    public float spawnRadius = 15;
    public float spawnHeight = 10;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            float y = Random.Range(0, spawnHeight);
            SpawnRandomStar(y);    
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        // Si le timer atteint zéro, l'ennemi tire
        if (spawnTimer <= 0)
        {
            SpawnRandomStar(spawnHeight);
            spawnTimer = 1;
        }
    }
    
    void SpawnRandomStar(float y)
    {
        int a = Random.Range(0, stars.Length - 1);

        Debug.Log(a);

        GameObject starPrefab = stars[a];

        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRadius, spawnRadius), y, 0);

        GameObject star = Instantiate(starPrefab, spawnPosition, Quaternion.identity);
        star.transform.eulerAngles += new Vector3(1, 0, 0);
    }
}
