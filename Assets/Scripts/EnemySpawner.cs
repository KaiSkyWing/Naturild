using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnInterval = 3.0f;
    private bool isAlive = true;

    public List<EnemyController> enemiesSpawned = new List<EnemyController>();

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnEnemy());
        StartCoroutine(AccelerateSpawnInterval());
    }

    IEnumerator SpawnEnemy()
    {
        while (isAlive)
        {
            SpawnEnemyAtRandomLocation();
            
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator AccelerateSpawnInterval()
    {
        while (true)
        {
            spawnInterval -= 0.1f;
            if (spawnInterval <= 0.3f)
            {
                spawnInterval = 0.3f;
            }
            yield return new WaitForSeconds(3.0f);
        }
    }

    void SpawnEnemyAtRandomLocation()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        Vector3 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ScreenToWorldPoint(new Vector3(screenWidth, screenHeight, mainCamera.nearClipPlane));

        // Randomly select one of the four edges and spawn an enemy just outside the screen
        float randomValue = Random.value;
        Vector3 spawnPosition = Vector3.zero;

        if (randomValue < 0.25f)
        {
            // Spawn just to the left of the screen
            spawnPosition = new Vector3(bottomLeft.x - 1, Random.Range(bottomLeft.y, topRight.y), 0);
        }
        else if (randomValue < 0.5f)
        {
            // Spawn just to the right of the screen
            spawnPosition = new Vector3(topRight.x + 1, Random.Range(bottomLeft.y, topRight.y), 0);
        }
        else if (randomValue < 0.75f)
        {
            // Spawn just below the screen
            spawnPosition = new Vector3(Random.Range(bottomLeft.x, topRight.x), bottomLeft.y - 1, 0);
        }
        else
        {
            // Spawn just above the screen
            spawnPosition = new Vector3(Random.Range(bottomLeft.x, topRight.x), topRight.y + 1, 0);
        }

        GameObject spawnedenemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
        enemiesSpawned.Add(spawnedenemy.GetComponent<EnemyController>());
    }

    public void EnemySpawnerStop()
    {
        isAlive = false;
    }
    public void EnemySpawnerStart()
    {
        isAlive = true;
        StartCoroutine(SpawnEnemy());
        StartCoroutine(AccelerateSpawnInterval());
    }

    public void EnemyStop()
    {
        foreach (EnemyController e in enemiesSpawned)
        {
            e.EnemyStop();
        }
    }

    public void EnemyStart()
    {
        foreach (EnemyController e in enemiesSpawned)
        {
            e.EnemyStart();
        }
    }
}
