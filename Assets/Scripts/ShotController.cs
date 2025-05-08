using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    public float speed = 5f;
    public float searchRadius = 2.5f; // Search radius for finding enemies
    private Vector3 targetDirection;
    private bool isAlive = true;

    public GameObject exp;

    public AudioSource deadSound;

    // Start is called before the first frame update
    void Start()
    {
        FindClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
            MoveInTargetDirection();
        }
    }

    void FindClosestEnemy()
    {
        if (isAlive)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float closestDistance = Mathf.Infinity;
            GameObject closestEnemy = null;

            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < closestDistance && distanceToEnemy <= searchRadius)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }

            if (closestEnemy != null)
            {
                targetDirection = (closestEnemy.transform.position - transform.position).normalized;
            }
            else
            {
                // If no enemy is found within the search radius, move in a random direction
                targetDirection = Random.insideUnitCircle.normalized;
            }

            // Optional: Rotate the shot to face the target direction
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    void MoveInTargetDirection()
    {
        transform.position += targetDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Instantiate(exp, transform.position, Quaternion.identity);
            // Handle collision with enemy (e.g., destroy shot and enemy)

            //Instantiate(deadSound, transform.position, Quaternion.identity);
            //deadSound.Play();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void ShotStop()
    {
        isAlive = false;
    }

     public void ShotStart()
    {
        isAlive = true;
    }
}
