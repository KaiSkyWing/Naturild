using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopButtonController : MonoBehaviour
{
    private int item1On = 0;
    private int item2On = 0;
    private int item3On = 0;
    private int item4On = 0;
    private int item5On = 0;
    private int item6On = 0;
    private int item7On = 0;
    private int item8On = 0;


    public GameObject filter1;
    public GameObject filter2;
    public GameObject filter3;
    public GameObject filter4;
    public GameObject filter5;
    public GameObject filter6;
    public GameObject filter7;
    public GameObject filter8;


    public int coin1 = 1000;
    public int fire1 = 100;
    public int water1 = 100;

    public int coin2 = 2000;
    public int fire2 = 200;
    public int water2 = 200;

    public int coin3 = 3000;
    public int fire3 = 300;
    public int water3 = 300;

    public int coin4 = 4000;
    public int fire4 = 400;
    public int water4 = 400;

    public int coin5 = 5000;
    public int fire5 = 500;
    public int water5 = 500;

    public int coin6 = 6000;
    public int fire6 = 600;
    public int water6 = 600;

    public int coin7 = 7000;
    public int fire7 = 700;
    public int water7 = 700;

    public int coin8 = 8000;
    public int fire8 = 800;
    public int water8 = 800;

    private int coinNum;
    private int fireItemNum;
    private int waterItemNum;

    public ShopUIController shopUIController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        item1On = PlayerPrefs.GetInt("Item1");
        item2On = PlayerPrefs.GetInt("Item2");
        item3On = PlayerPrefs.GetInt("Item3");
        item4On = PlayerPrefs.GetInt("Item4");
        item5On = PlayerPrefs.GetInt("Item5");
        item6On = PlayerPrefs.GetInt("Item6");
        item7On = PlayerPrefs.GetInt("Item7");
        item8On = PlayerPrefs.GetInt("Item8");

        coinNum = PlayerPrefs.GetInt("Coins");
        fireItemNum = PlayerPrefs.GetInt("FireItem");
        waterItemNum = PlayerPrefs.GetInt("WaterItem");
        RemoverFilter();
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Menu");
    }

    private void SaveCoinFireNum(int coinCount, int fireCount, int waterCount)
    {
        coinNum -= coinCount;
        fireItemNum -= fireCount;
        waterItemNum -= waterCount;
        PlayerPrefs.SetInt("Coins", coinNum);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("FireItem", fireItemNum);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("WaterItem", waterItemNum);
        PlayerPrefs.Save();
    }


    //まとめてかけるのはわかってますが、仕上げの時間がないのでこのままで行きます
    private void RemoverFilter()
    {
        if (coinNum >= coin1 && fireItemNum >= fire1 && item1On == 0 && waterItemNum >= water1)
        {
            filter1.SetActive(false);
        }
        else
        {
            filter1.SetActive(true);
        }
        if (coinNum >= coin2 && fireItemNum >= fire2 && item2On == 0 && waterItemNum >= water2)
        {
            filter2.SetActive(false);
        }
        else
        {
            filter2.SetActive(true);
        }
        if (coinNum >= coin3 && fireItemNum >= fire3 && item3On == 0 && waterItemNum >= water3)
        {
            filter3.SetActive(false);
        }
        else
        {
            filter3.SetActive(true);
        }
        if (coinNum >= coin4 && fireItemNum >= fire4 && item4On == 0 && waterItemNum >= water4)
        {
            filter4.SetActive(false);
        }
        else
        {
            filter4.SetActive(true);
        }
        if (coinNum >= coin5 && fireItemNum >= fire5 && item5On == 0 && waterItemNum >= water5)
        {
            filter5.SetActive(false);
        }
        else
        {
            filter5.SetActive(true);
        }
        if (coinNum >= coin6 && fireItemNum >= fire6 && item6On == 0 && waterItemNum >= water6 && item4On == 1)
        {
            filter6.SetActive(false);
        }
        else
        {
            filter6.SetActive(true);
        }
        if (coinNum >= coin7 && fireItemNum >= fire7 && item7On == 0 && waterItemNum >= water7 && item5On == 1)
        {
            filter7.SetActive(false);
        }
        else
        {
            filter7.SetActive(true);
        }
        if (coinNum >= coin8 && fireItemNum >= fire8 && item8On == 0 && waterItemNum >= water8)
        {
            filter8.SetActive(false);
        }
        else
        {
            filter8.SetActive(true);
        }
    }

            public void Item1On()
    {
        if (coinNum >= coin1 && fireItemNum >= fire1 && item1On == 0 && waterItemNum >= water1)
        {
            item1On = 1;
            SaveCoinFireNum(coin1, fire1, water1);
            PlayerPrefs.SetInt("Item1", 1);
            PlayerPrefs.Save();
        }
    }

    public void Item2On()
    {
        if (coinNum >= coin2 && fireItemNum >= fire2 && item2On == 0 && waterItemNum >= water2)
        {
            item2On = 1;
            SaveCoinFireNum(coin2, fire2, water2);
            PlayerPrefs.SetInt("Item2", 1);
            PlayerPrefs.Save();
        }
    }

    public void Item3On()
    {
        if (coinNum >= coin3 && fireItemNum >= fire3 && item3On == 0 && waterItemNum >= water3)
        {
            item3On = 1;
            SaveCoinFireNum(coin3, fire3, water3);
            PlayerPrefs.SetInt("Item3", 1);
            PlayerPrefs.Save();
        }
    }

    public void Item4On()
    {
        if (coinNum >= coin4 && fireItemNum >= fire4 && item4On == 0 && waterItemNum >= water4)
        {
            item4On = 1;
            SaveCoinFireNum(coin4, fire4, water4);
            PlayerPrefs.SetInt("Item4", 1);
            PlayerPrefs.Save();
        }
    }

    public void Item5On()
    {
        if (coinNum >= coin5 && fireItemNum >= fire5 && item5On == 0 && waterItemNum >= water5)
        {
            item5On = 1;
            SaveCoinFireNum(coin5, fire5, water5);
            PlayerPrefs.SetInt("Item5", 1);
            PlayerPrefs.Save();
        }
    }

    public void Item6On()
    {
        if (coinNum >= coin6 && fireItemNum >= fire6 && item6On == 0 && waterItemNum >= water6 && item4On == 1)
        {
            item6On = 1;
            SaveCoinFireNum(coin6, fire6, water6);
            PlayerPrefs.SetInt("Item6", 1);
            PlayerPrefs.Save();
        }
    }

    public void Item7On()
    {
        if (coinNum >= coin7 && fireItemNum >= fire7 && item7On == 0 && waterItemNum >= water7 && item5On == 1)
        {
            item7On = 1;
            SaveCoinFireNum(coin7, fire7, water7);
            PlayerPrefs.SetInt("Item7", 1);
            PlayerPrefs.Save();
        }
    }

    
    public void Item8On()
    {
        if (coinNum >= coin8 && fireItemNum >= fire8 && item8On == 0 && waterItemNum >= water8)
        {
            item8On = 1;
            SaveCoinFireNum(coin8, fire8, water8);
            PlayerPrefs.SetInt("Item8", 1);
            PlayerPrefs.Save();
        }
    }
}
