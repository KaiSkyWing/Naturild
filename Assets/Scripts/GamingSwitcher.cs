using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamingSwitcher : MonoBehaviour
{
    public GameObject fire;
    public GameObject water;
    public GameObject campfire;
    public GameObject pond;

    public Image lvup2, lvup3, lvup5, lvup6;

    public Sprite lvup2_1, lvup2_2, lvup3_1, lvup3_2, lvup5_1, lvup5_2, lvup6_1, lvup6_2;

    private int isRainingInt = 0;
    private bool isRainig;

    // Start is called before the first frame update
    void Start()
    {
        ChangeSetting();
        ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeSetting()
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

        water.SetActive(isRainig);
        pond.SetActive(isRainig);
        fire.SetActive(!isRainig);
        campfire.SetActive(!isRainig);
    }

    private void ChangeSprite()
    {
        if (isRainig)
        {
            lvup2.sprite = lvup2_2;
            lvup3.sprite = lvup3_2;
            lvup5.sprite = lvup5_2;
            lvup6.sprite = lvup6_2;
        }
        else
        {
            lvup2.sprite = lvup2_1;
            lvup3.sprite = lvup3_1;
            lvup5.sprite = lvup5_1;
            lvup6.sprite = lvup6_1;
        }
    }



}
