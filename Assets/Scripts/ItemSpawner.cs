using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject logHealingItem;
    public GameObject crystalHealingItem;
    public float spawnInterval = 10.0f;
    public float minSpawnDistance = 5.0f;
    public int maxItems = 3;
    private bool isAlive = true;

    private GameObject newItem;

    private Queue<GameObject> spawnedItems = new Queue<GameObject>();

    private int isRainingInt = 0;
    private bool isRainig;
        // Start is called before the first frame update
        void Start()
    {
        isRainingInt = PlayerPrefs.GetInt("IsRain");

        if (isRainingInt == 1)
        {
            isRainig = true;
        }
        else
        {
            isRainig = false;
        }
        StartCoroutine(SpawnItem());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnItem()
    {
        while (isAlive)
        {
            SpawnItemAtRandomLocation();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnItemAtRandomLocation()
    {
        Vector2 randomPosition = GetRandomPosition();

        if (isRainig)
        {
            newItem = Instantiate(crystalHealingItem, randomPosition, Quaternion.identity);
        }
        else
        {
            newItem = Instantiate(logHealingItem, randomPosition, Quaternion.identity);
        }

        spawnedItems.Enqueue(newItem);
        if (spawnedItems.Count > maxItems)
        {
            DestroyOldestItem();
        }
    }

    Vector2 GetRandomPosition()
    {
        Camera mainCamera = Camera.main;
        Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

        Vector2 randomPosition;
        do
        {
            float randomAngle = Random.Range(0, Mathf.PI * 2);
            float randomDistance = Random.Range(minSpawnDistance, Mathf.Min(screenBounds.x, screenBounds.y));

            randomPosition = new Vector2(
                randomDistance * Mathf.Cos(randomAngle),
                randomDistance * Mathf.Sin(randomAngle)
            );
        } while (!IsWithinScreenBounds(randomPosition, screenBounds));

        return randomPosition;
    }

    bool IsWithinScreenBounds(Vector2 position, Vector2 screenBounds)
    {
        return position.x > -screenBounds.x && position.x < screenBounds.x &&
               position.y > -screenBounds.y && position.y < screenBounds.y;
    }

    void DestroyOldestItem()
    {
        if (spawnedItems.Count > 0)
        {
            GameObject oldestItem = spawnedItems.Dequeue();
            Destroy(oldestItem);
        }
    }

    public void ItemSpawnerStop()
    {
        isAlive = false;
    }
    public void ItemSpawnerStart()
    {
        isAlive = true;
        StartCoroutine(SpawnItem());
    }
}
