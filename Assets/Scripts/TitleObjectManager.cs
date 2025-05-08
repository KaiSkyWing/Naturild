using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleObjectManager : MonoBehaviour
{
    private int item1On;
    private int item2On;
    private int item3On;
    private int item4On;
    private int item5On;
    private int item6On;
    private int item7On;
    private int item8On;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Item4;
    public GameObject Item5;
    public GameObject Item6;
    public GameObject Item7;
    public GameObject Item8;

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

        ActivateAndDeactivate(item1On, Item1);
        ActivateAndDeactivate(item2On, Item2);
        ActivateAndDeactivate(item3On, Item3);
        ActivateAndDeactivate(item4On, Item4);
        ActivateAndDeactivate(item5On, Item5);
        ActivateAndDeactivate(item6On, Item6);
        ActivateAndDeactivate(item7On, Item7);
        ActivateAndDeactivate(item8On, Item8);

    }

    public void ActivateAndDeactivate(int itemOn, GameObject itemNum)
    {
        if (itemOn == 1)
        {
            itemNum.SetActive(true);
        }
        else
        {
            itemNum.SetActive(false);
        }
    }
}
