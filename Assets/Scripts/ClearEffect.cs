using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class ClearEffect : MonoBehaviour
{
    public ShotController shotController;
    public ItemSpawner itemSpawner;
    public EnemySpawner enemySpawner;
    public PlayerController playerController;

    public Canvas clearCanvas;
    public Canvas campfireCanvas;
    public Canvas pondCanvas;
    public Canvas gMCanvas;
    public Canvas gameOverCanvas;

    public Text clearFireItemNumText;
    public Text clearWaterItemNumText;
    public Text clearCoinNumText;

    public Text gOFireItemNumText;
    public Text gOWaterItemNumText;
    public Text gOCoinNumText;

    public Image elementItem;
    public Image gOElementItem;

    public Sprite fire, water;

    public bool isClear;

    public PostProcessVolume postProcessVolume;
    private PostProcessProfile postProcessProfile;
    private DepthOfField depthOfField;

    private int roundFireItemNum;
    public static int fireItemNum;

    private int roundWaterItemNum;
    public static int waterItemNum;

    private int roundCoinNum;
    public static int coinNum;

    private int isRainingInt = 0;
    private bool isRainig;

    // Start is called before the first frame update
    void Start()
    {
        fireItemNum = PlayerPrefs.GetInt("FireItem");
        waterItemNum = PlayerPrefs.GetInt("WaterItem");
        coinNum = PlayerPrefs.GetInt("Coins");
        isClear = false;



        isRainingInt = PlayerPrefs.GetInt("IsRain");

        if (isRainingInt == 1)
        {
            isRainig = true;
        }
        else
        {
            isRainig = false;
        }

        ChangeSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if(isClear)
        {
            if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void GameClear()
    {
        shotController.ShotStop();
        itemSpawner.ItemSpawnerStop();
        enemySpawner.EnemySpawnerStop();
        enemySpawner.EnemyStop();
        playerController.PlayerStop();

        ClearGameWindow();
    }

    public void ClearGameWindow()
    {
        if (isRainig)
        {
            roundWaterItemNum = 250;
            waterItemNum += roundWaterItemNum;
            clearWaterItemNumText.text = roundWaterItemNum.ToString();
            PlayerPrefs.SetInt("WaterItem", waterItemNum);
            PlayerPrefs.Save();
        }
        else
        {
            roundFireItemNum = 250;
            fireItemNum += roundFireItemNum;
            clearFireItemNumText.text = roundFireItemNum.ToString();
            PlayerPrefs.SetInt("FireItem", fireItemNum);
            PlayerPrefs.Save();
        }


        roundCoinNum = 3000;
        coinNum += roundCoinNum;
        clearCoinNumText.text = roundCoinNum.ToString();
        PlayerPrefs.SetInt("Coins", coinNum);
        PlayerPrefs.Save();


        Time.timeScale = 0;
        clearCanvas.gameObject.SetActive(true);
        campfireCanvas.gameObject.SetActive(false);
        pondCanvas.gameObject.SetActive(false);
        gMCanvas.gameObject.SetActive(false);
        postProcessProfile = postProcessVolume.profile;
        if (postProcessProfile.TryGetSettings<DepthOfField>(out depthOfField))
        {
            depthOfField.focalLength.value = 50f;
        }
        isClear = true;
        
    }

    public void GameOver()
    {
        if (isRainig)
        {
            roundWaterItemNum = 250;
            waterItemNum += roundWaterItemNum;
            clearWaterItemNumText.text = roundWaterItemNum.ToString();
            PlayerPrefs.SetInt("WaterItem", waterItemNum);
            PlayerPrefs.Save();
        }
        else
        {
            roundFireItemNum = 50;
            fireItemNum += roundFireItemNum;
            gOFireItemNumText.text = roundFireItemNum.ToString();
            PlayerPrefs.SetInt("FireItem", fireItemNum);
            PlayerPrefs.Save();
        }

        roundCoinNum = 500;
        coinNum += roundCoinNum;
        gOCoinNumText.text = roundCoinNum.ToString();
        PlayerPrefs.SetInt("Coins", coinNum);
        PlayerPrefs.Save();

        Time.timeScale = 0;
        gameOverCanvas.gameObject.SetActive(true);
        campfireCanvas.gameObject.SetActive(false);
        pondCanvas.gameObject.SetActive(false);
        postProcessProfile = postProcessVolume.profile;
        if (postProcessProfile.TryGetSettings<DepthOfField>(out depthOfField))
        {
            depthOfField.focalLength.value = 50f;
        }
    }

    public void RestartGameTimer()
    {
        Time.timeScale = 1;
    }

    private void ChangeSprite()
    {
        if (isRainig)
        {
            elementItem.sprite = water;
            gOElementItem.sprite = water;
        }
        else
        {
            elementItem.sprite = fire;
            gOElementItem.sprite = fire;
        }
    }
}
