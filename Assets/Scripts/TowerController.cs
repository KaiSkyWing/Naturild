using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class TowerController : MonoBehaviour
{
    public int towermaxHp = 20;
    public int towerHp;
    public Slider fireslider;
    public FadeOutEffect fadeOutEffect;

    public ShotController shotController;
    public ItemSpawner itemSpawner;
    public EnemySpawner enemySpawner;
    public PlayerController playerController;
    public GameUIController uIController;
    public ClearEffect clearEffect;

    public Canvas pauseCanvas;
    public Canvas campfireCanvas;
    public Canvas pondCanvas;
    public Canvas gMCanvas;
    public Canvas LvUPCanvas;

    private bool isPaused = false;
    private bool isLvPaused = false;

    private int isRainingInt = 0;
    private bool isRainig;

    private List<PowerUPs> powerUPList;
    public Button playerSpUP;
    public Button shotSpUP;
    public Button shotFqUP;
    public Button maxHPUP;
    public Button shotRangeUP;
    public Button detectRangeUP;

    public Image pauseImage;

    public Transform shootableRange;
    public Transform detectableRange;

    public PostProcessVolume postProcessVolume;
    private PostProcessProfile postProcessProfile;
    private DepthOfField depthOfField;

    private enum PowerUPs
    {
        PlayerSpUP,
        ShotSpUP,
        ShotFqUP,
        MaxHPUP,
        ShotRangeUP,
        DetectRangeUP,
    }
    private PowerUPs chosenType;

    void Start()
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

        powerUPList = Enum.GetValues(typeof(PowerUPs))
            .Cast<PowerUPs>()
            .ToList();


        gameObject.transform.localScale = new Vector3(1f, 1f, 0);
        towerHp = towermaxHp;

        fireslider.maxValue = towermaxHp;
        fireslider.value = towermaxHp;
    }

    void Update()
    {
        fireslider.value = towerHp;
        if (towerHp > towermaxHp)
        {
            towerHp = towermaxHp;
        }
        Debug.Log(isPaused);
        if (Input.GetKeyDown(KeyCode.Space))
            if (isLvPaused == false && clearEffect.isClear == false)
            {
                if (isPaused)
                {
                    GameStart();
                    isPaused = false;
                }
                else
                {
                    GamePause();
                    isPaused = true;
                }
            }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            towerHp--;
            if (towerHp <= 0)
            {
                gMCanvas.gameObject.SetActive(false);
                gameObject.transform.localScale = new Vector3(0, 0, 0);
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        uIController.StopCounting();
        shotController.ShotStop();
        itemSpawner.ItemSpawnerStop();
        enemySpawner.EnemySpawnerStop();
        enemySpawner.EnemyStop();
        playerController.PlayerStop();
        
        fadeOutEffect.StartFadeOut();
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        pauseCanvas.gameObject.SetActive(true);
        campfireCanvas.gameObject.SetActive(false);
        pondCanvas.gameObject.SetActive(false);
        gMCanvas.gameObject.SetActive(false);

        postProcessProfile = postProcessVolume.profile;
        if (postProcessProfile.TryGetSettings<DepthOfField>(out depthOfField))
        {
            depthOfField.focalLength.value = 50f;
        }
        MovePauseImage();

    }

    public void GameStart()
    {
        Time.timeScale = 1;
        pauseCanvas.gameObject.SetActive(false);
        if(isRainig)
        {
            pondCanvas.gameObject.SetActive(true);
        }
        else
        {
            campfireCanvas.gameObject.SetActive(true);
        }
        gMCanvas.gameObject.SetActive(true);

        postProcessProfile = postProcessVolume.profile;
        if (postProcessProfile.TryGetSettings<DepthOfField>(out depthOfField))
        {
            depthOfField.focalLength.value = 1f;
        }
    }

    public void LvUPPause()
    {
        isLvPaused = true;
        Time.timeScale = 0;
        LvUPCanvas.gameObject.SetActive(true);
        campfireCanvas.gameObject.SetActive(false);
        pondCanvas.gameObject.SetActive(false);
        gMCanvas.gameObject.SetActive(false);
        ChoosePowerUPs();

        postProcessProfile = postProcessVolume.profile;
        if (postProcessProfile.TryGetSettings<DepthOfField>(out depthOfField))
        {
            depthOfField.focalLength.value = 50f;
        }

    }

    public void LvUPClicked()
    {
        isLvPaused = false;
        Time.timeScale = 1;
        LvUPCanvas.gameObject.SetActive(false);
        if (isRainig)
        {
            pondCanvas.gameObject.SetActive(true);
            Debug.Log("clicked and set active");
        }
        else
        {
            campfireCanvas.gameObject.SetActive(true);
        }
        gMCanvas.gameObject.SetActive(true);

        postProcessProfile = postProcessVolume.profile;
        if (postProcessProfile.TryGetSettings<DepthOfField>(out depthOfField))
        {
            depthOfField.focalLength.value = 1f;
        }
    }

    public void ChoosePowerUPs()
    {
        ChooseRandomPowerUP();
    }

    private void ChooseRandomPowerUP()
    {
        if (powerUPList == null)
        {
            Debug.Log("powerUpList is Null");
        }
        else
        {
            powerUPList = powerUPList.OrderBy(a => Guid.NewGuid()).ToList();
        }
        

        for (int i = 0; i < 3; i++)
        {
            chosenType = powerUPList[i];
            if (chosenType.ToString() == "PlayerSpUP")
            {
                playerSpUP.gameObject.SetActive(true);
                SetPosition(playerSpUP, i);
            }
            if (chosenType.ToString() == "ShotSpUP")
            {
                shotSpUP.gameObject.SetActive(true);
                SetPosition(shotSpUP, i);
            }
            if (chosenType.ToString() == "ShotFqUP")
            {
                shotFqUP.gameObject.SetActive(true);
                SetPosition(shotFqUP, i);
            }
            if (chosenType.ToString() == "MaxHPUP")
            {
                maxHPUP.gameObject.SetActive(true);
                SetPosition(maxHPUP, i);
            }
            if (chosenType.ToString() == "ShotRangeUP")
            {
                shotRangeUP.gameObject.SetActive(true);
                SetPosition(shotRangeUP, i);
            }
            if (chosenType.ToString() == "DetectRangeUP")
            {
                detectRangeUP.gameObject.SetActive(true);
                SetPosition(detectRangeUP, i);
            }
        }
    }


    public void SetPosition(Button buttonType, int num)
    {
        RectTransform rectTransform;
        rectTransform = buttonType.GetComponent<RectTransform>();

        float x = 1;
        if (num == 0)
        {
            x = -400f;
            Debug.Log(x);
        }
        else if (num == 1)
        {
            x = 0f;
        }
        else if (num == 2)
        {
            x = 400f;
        }

        rectTransform.anchoredPosition = new Vector2(x, 0);
    }

    public void PlayerSpeedUP()
    {
        playerController.moveSpeed += 0.1f;
        PowerUPsInvisible();
    }

    public void ShotSpeedUP()
    {
        shotController.speed += 0.5f;
        PowerUPsInvisible();
    }

    public void ShotFrequencyUP()
    {
        playerController.shotInterval -= 0.05f;
        PowerUPsInvisible();
    }

    public void MaxHPUP()
    {
        towermaxHp += 3;
        towerHp += 3;
        PowerUPsInvisible();
    }

    public void ShotableRangeUP()
    {
        playerController.shotRadius += 0.5f;
        shootableRange.localScale = new Vector3(playerController.shotRadius * 2, playerController.shotRadius * 2, 1);
        PowerUPsInvisible();
    }

    public void DetectableRangeUP()
    {
        shotController.searchRadius += 0.3f;
        detectableRange.localScale = new Vector3(shotController.searchRadius * 5, shotController.searchRadius * 5, 1);
        PowerUPsInvisible();
    }

    public void PowerUPsInvisible()
    {
        playerSpUP.gameObject.SetActive(false);
        shotSpUP.gameObject.SetActive(false);
        shotFqUP.gameObject.SetActive(false);
        maxHPUP.gameObject.SetActive(false);
        shotRangeUP.gameObject.SetActive(false);
        detectRangeUP.gameObject.SetActive(false);
    }

    
    public void MovePauseImage()
    {
        
        StartCoroutine(StartMovePauseImage());
    }

    
    IEnumerator StartMovePauseImage()
    {
        pauseImage.rectTransform.anchoredPosition = new Vector2(-1000, -185);
        Debug.Log(pauseImage.rectTransform.anchoredPosition.x);
        while (pauseImage.rectTransform.anchoredPosition.x < - 450)
        {
            Vector2 currentPositon = pauseImage.rectTransform.anchoredPosition;
            pauseImage.rectTransform.anchoredPosition = new Vector2(currentPositon.x +  10, currentPositon.y);
            yield return null;
        }
    }

}
