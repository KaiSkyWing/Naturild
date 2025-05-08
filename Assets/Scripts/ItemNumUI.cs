using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemNumUI : MonoBehaviour
{
    public Text coinNumText;
    public Text fireItemNumText;
    public Text waterItemNumText;

    public int coinNum;
    public int fireItemNum;
    public int waterItemNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinNum = PlayerPrefs.GetInt("Coins");
        fireItemNum = PlayerPrefs.GetInt("FireItem");
        waterItemNum = PlayerPrefs.GetInt("WaterItem");

        coinNumText.text = coinNum.ToString();
        fireItemNumText.text = fireItemNum.ToString();
        waterItemNumText.text = waterItemNum.ToString();
    }
}
