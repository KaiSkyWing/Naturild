using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdleItemController : MonoBehaviour
{
    private int isRainingInt;
    private bool isRaining;

    private int coinNum;
    private int fireItemNum;
    private int waterItemNum;

    public GameObject gotItemCanvas;

    public Image itemImage;
    public Sprite fireSprite;
    public Sprite waterSprite;

    // Start is called before the first frame update
    void Start()
    {
        coinNum = PlayerPrefs.GetInt("Coins");
        fireItemNum = PlayerPrefs.GetInt("FireItem");
        waterItemNum = PlayerPrefs.GetInt("WaterItem");
        CheckWeather();
        StartCoroutine(GetSomeItem());
    }

    // Update is called once per frame
    void Update()
    {
        CheckWeather();
    }

    private void CheckWeather()
    {
        isRainingInt = PlayerPrefs.GetInt("IsRain");

        if (isRainingInt == 1)
        {
            isRaining = true;
        }
        else
        {
            isRaining = false;
        }
    }

    IEnumerator GetSomeItem()
    {
        while (true)
        {
            if (isRaining)
            {
                waterItemNum += 1;
                PlayerPrefs.SetInt("WaterItem", waterItemNum);
                itemImage.sprite = waterSprite;
            }
            else
            {
                fireItemNum += 1;
                PlayerPrefs.SetInt("FireItem", fireItemNum);
                itemImage.sprite = fireSprite;
            }
            PlayerPrefs.Save();

            StartCoroutine(ShowCanvas());

            yield return new WaitForSeconds(60f);
            // Wait for a random interval before activating the next animal button
        }
    }

    IEnumerator ShowCanvas()
    {
        int count = 0;
        gotItemCanvas.SetActive(true);
        while (count < 5)
        {
            count += 1;
            yield return new WaitForSeconds(1f);
        }
        gotItemCanvas.SetActive(false);
    }
}
