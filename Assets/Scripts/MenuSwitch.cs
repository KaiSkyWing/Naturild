using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSwitch : MonoBehaviour
{
    public GameObject fire;
    public GameObject water;
    public GameObject campfire;
    public GameObject stone;
    public GameObject rains;
    public GameObject grassWithFire;
    public GameObject grassWithPond;

    public SoundController soundController;

    private int isRainingInt;
    private bool isRaining;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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

        water.SetActive(isRaining);
        stone.SetActive(isRaining);
        grassWithPond.SetActive(isRaining);

        fire.SetActive(!isRaining);
        grassWithFire.SetActive(!isRaining);
        campfire.SetActive(!isRaining);

        

        rains.SetActive(isRaining);
    }

}
