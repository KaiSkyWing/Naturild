using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button startButton;
    public Button shopButton;
    public ShopUIController shopUIController;
    public SoundController soundController;
    public GameObject settingCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvisibleButton()
    {
        startButton.interactable = false;
    }

    public void VisibleButton()
    {
        startButton.interactable = true;
    }

    public void StartGame()
    {
        InvisibleButton();
        SceneManager.LoadScene("Gaming");
    }

    public void ResetScore()
    {
        PlayerPrefs.DeleteKey("Coins");
        PlayerPrefs.DeleteKey("FireItem");
        PlayerPrefs.DeleteKey("WaterItem");
        PlayerPrefs.DeleteKey("Item1");
        PlayerPrefs.DeleteKey("Item2");
        PlayerPrefs.DeleteKey("Item3");
        PlayerPrefs.DeleteKey("Item4");
        PlayerPrefs.DeleteKey("Item5");
        PlayerPrefs.DeleteKey("Item6");
        PlayerPrefs.DeleteKey("Item7");
        PlayerPrefs.DeleteKey("Item8");
        PlayerPrefs.DeleteKey("DeerOn");
        PlayerPrefs.DeleteKey("SnailOn");
        PlayerPrefs.DeleteKey("SquirrelOn");
        PlayerPrefs.DeleteKey("RabbitOn");
        PlayerPrefs.DeleteKey("FoxOn");
        PlayerPrefs.DeleteKey("FrogOn");
        PlayerPrefs.DeleteKey("OwlOn");
        PlayerPrefs.DeleteKey("BatOn");
    }

    public void GoShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GetMany()
    {
        PlayerPrefs.SetInt("FireItem", 10000);
        PlayerPrefs.SetInt("WaterItem", 10000);
        PlayerPrefs.SetInt("Coins", 100000);
        PlayerPrefs.Save();
    }

    public void GoBook()
    {
        SceneManager.LoadScene("Book");
    }

    public void GoCliff()
    {
        SceneManager.LoadScene("Cliff");
    }

    public void ShowSetting()
    {
        settingCanvas.SetActive(true);
    }

    public void GoBack()
    {
        settingCanvas.SetActive(false);
    }
}
