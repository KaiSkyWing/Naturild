using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject tower;
    public float speed = 2.0f;
    public PlayerController playerController;
    
    private bool isAlive = true;

    private bool isFlipped = false;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); // Find and assign the PlayerController
    }

    void Update()
    {
        if (isAlive)
        {

            if (transform.position.x < 0 && !isFlipped)
            {
                Flip();
            }

            Vector3 direction = tower.transform.position - transform.position;
            direction.Normalize();

            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void EnemyStop()
    {
        isAlive = false;
    }

    public void EnemyStart()
    {
        isAlive = true;
    }

    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        isFlipped = true;
    }
}

