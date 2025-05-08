using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIController : MonoBehaviour
{
    public ShopButtonController shopButtonController;

    public Text coinText1;
    public Text fireText1;
    public Text waterText1;
    public Text soldOut1;
    public GameObject cost1;

    public Text coinText2;
    public Text fireText2;
    public Text waterText2;
    public Text soldOut2;
    public GameObject cost2;

    public Text coinText3;
    public Text fireText3;
    public Text waterText3;
    public Text soldOut3;
    public GameObject cost3;

    public Text coinText4;
    public Text fireText4;
    public Text waterText4;
    public Text soldOut4;
    public GameObject cost4;

    public Text coinText5;
    public Text fireText5;
    public Text waterText5;
    public Text soldOut5;
    public GameObject cost5;

    public Text coinText6;
    public Text fireText6;
    public Text waterText6;
    public Text soldOut6;
    public GameObject cost6;

    public Text coinText7;
    public Text fireText7;
    public Text waterText7;
    public Text soldOut7;
    public GameObject cost7;

    public Text coinText8;
    public Text fireText8;
    public Text waterText8;
    public Text soldOut8;
    public GameObject cost8;

    private int item1On;
    private int item2On;
    private int item3On;
    private int item4On;
    private int item5On;
    private int item6On;
    private int item7On;
    private int item8On;

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

        if (item1On == 1)
        {
            Buy1On(true);
        }
        if (item2On == 1)
        {
            Buy2On(true);
        }
        if (item3On == 1)
        {
            Buy3On(true);
        }
        if (item4On == 1)
        {
            Buy4On(true);
        }
        if (item5On == 1)
        {
            Buy5On(true);
        }
        if (item6On == 1)
        {
            Buy6On(true);
        }
        if (item7On == 1)
        {
            Buy7On(true);
        }
        if (item8On == 1)
        {
            Buy8On(true);
        }

        coinText1.text = shopButtonController.coin1.ToString();
        fireText1.text = shopButtonController.fire1.ToString();
        waterText1.text = shopButtonController.water1.ToString();

        coinText2.text = shopButtonController.coin2.ToString();
        fireText2.text = shopButtonController.fire2.ToString();
        waterText2.text = shopButtonController.water2.ToString();

        coinText3.text = shopButtonController.coin3.ToString();
        fireText3.text = shopButtonController.fire3.ToString();
        waterText3.text = shopButtonController.water3.ToString();

        coinText4.text = shopButtonController.coin4.ToString();
        fireText4.text = shopButtonController.fire4.ToString();
        waterText4.text = shopButtonController.water4.ToString();

        coinText5.text = shopButtonController.coin5.ToString();
        fireText5.text = shopButtonController.fire5.ToString();
        waterText5.text = shopButtonController.water5.ToString();

        coinText6.text = shopButtonController.coin6.ToString();
        fireText6.text = shopButtonController.fire6.ToString();
        waterText6.text = shopButtonController.water6.ToString();

        coinText7.text = shopButtonController.coin7.ToString();
        fireText7.text = shopButtonController.fire7.ToString();
        waterText7.text = shopButtonController.water7.ToString();

        coinText8.text = shopButtonController.coin8.ToString();
        fireText8.text = shopButtonController.fire8.ToString();
        waterText8.text = shopButtonController.water8.ToString();

    }


    public void Buy1On(bool onoff)
    {
        soldOut1.gameObject.SetActive(onoff);
        cost1.SetActive(!onoff);
    }
     
    public void Buy2On(bool onoff)
    {
        soldOut2.gameObject.SetActive(onoff);
        cost2.SetActive(!onoff);
    }

    public void Buy3On(bool onoff)
    {
        soldOut3.gameObject.SetActive(onoff);
        cost3.SetActive(!onoff);
    }

    public void Buy4On(bool onoff)
    {
        soldOut4.gameObject.SetActive(onoff);
        cost4.SetActive(!onoff);
    }

    public void Buy5On(bool onoff)
    {
        soldOut5.gameObject.SetActive(onoff);
        cost5.SetActive(!onoff);
    }

    public void Buy6On(bool onoff)
    {
        soldOut6.gameObject.SetActive(onoff);
        cost6.SetActive(!onoff);
    }

    public void Buy7On(bool onoff)
    {
        soldOut7.gameObject.SetActive(onoff);
        cost7.SetActive(!onoff);
    }

    public void Buy8On(bool onoff)
    {
        soldOut8.gameObject.SetActive(onoff);
        cost8.SetActive(!onoff);
    }

}
