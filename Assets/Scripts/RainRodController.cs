using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RainRodController : MonoBehaviour
{
    public GameObject rainOnOff;
    public Text check;

    private bool isRaining;
    private int isRainingInt;

    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowCheckText()
    {
        rainOnOff.SetActive(true);
        if (isRaining)
        {
            check.text = "Do you want to\nturn the rain off?";
        }
        else
        {
            check.text = "Do you want to\nturn the rain on?";
        }
    }

    public void No()
    {
        rainOnOff.SetActive(false);
    }

    public void Yes()
    {
        StartAndStopRain();
        rainOnOff.SetActive(false);
    }

    private void StartAndStopRain()
    {
        isRaining = !isRaining;
        if (isRaining)
        {
            PlayerPrefs.SetInt("IsRain", 1);
            PlayerPrefs.Save();
        }
        else
        {
            PlayerPrefs.SetInt("IsRain", 0);
            PlayerPrefs.Save();
        }
    }
}
