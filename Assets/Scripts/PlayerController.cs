using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public GameObject shot;
    public float shotRadius = 4f;
    public float shotInterval = 0.5f; // Time interval between shots
    public TowerController towerController;
    public int exp = 0;
    public int level = 1;

    public int expMax;
    public Slider expSlider;

    private bool isAlive = true;

    void Start()
    {
        expMax = 3;
        expSlider.value = 0;
        exp = 0;
        StartCoroutine(ShootAtIntervals());
    }

    void Update()
    {
        if (isAlive)
        {
            expSlider.value = exp;
            expSlider.maxValue = expMax;
            print(exp);
            if (exp >= expMax)
            {
                exp -= expMax;
                level++;
                expMax++;
                LvUP();
            }

            Vector3 mouseScreenPosition = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
            mouseWorldPosition.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, mouseWorldPosition, moveSpeed * Time.deltaTime);

            Vector3 clampedPosition = transform.position;
            Vector3 screenMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z));
            Vector3 screenMax = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, transform.position.z));

            clampedPosition.x = Mathf.Clamp(clampedPosition.x, screenMin.x + 1, screenMax.x - 1);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, screenMin.y + 1, screenMax.y - 1);

            transform.position = clampedPosition;
        }
    }

    IEnumerator ShootAtIntervals()
    {
        while (isAlive)
        {
            Vector3 screenCenter = new Vector3(0, 0, 0);
            float distanceFromCenter = Vector3.Distance(transform.position, screenCenter);

            if (distanceFromCenter <= shotRadius)
            {
                Instantiate(shot, transform.position, transform.rotation);
            }

            yield return new WaitForSeconds(shotInterval);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            exp++;
        }
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            towerController.towerHp += 5;
        }
        if (other.CompareTag("Exp"))
        {
            Destroy(other.gameObject);
            exp++;
        }
    }

    public void PlayerStop()
    {
        isAlive = false;
    }

    public void PlayerStart()
    {
        isAlive = true;
        StartCoroutine(ShootAtIntervals());
    }

    public void LvUP()
    {
        towerController.LvUPPause();
    }
}
