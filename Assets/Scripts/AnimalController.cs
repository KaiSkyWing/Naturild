using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalController : MonoBehaviour
{
    public Button deerButton;
    public Button snailButton;
    public Button squirrelButton;
    public Button rabbitButton;
    public Button foxButton;
    public Button frogButton;
    public Button owlButton;
    public Button batButton;

    public GameObject showAdditionCanvas;
    public Text fireNumText;
    public Text waterNumText;
    public Image animalImage;

    public Sprite deerSprite;
    public Sprite snailSprite;
    public Sprite squirrelSprite;
    public Sprite rabbitSprite;
    public Sprite foxSprite;
    public Sprite frogSprite;
    public Sprite owlSprite;
    public Sprite batSprite;

    private int coinNum;
    private int fireItemNum;
    private int waterItemNum;

    private bool isDeerOn = false;
    private bool isSnailOn = false;
    private bool isSquirrelOn = false;
    private bool isRabbitOn = false;
    private bool isFoxOn = false;
    private bool isFrogOn = false;
    private bool isOwlOn = false;
    private bool isBatOn = false;

    private int isRainingInt;
    private bool isRaining;

    private List<Button> animalButtons;

    // Start is called before the first frame update
    void Start()
    {
        coinNum = PlayerPrefs.GetInt("Coins");
        fireItemNum = PlayerPrefs.GetInt("FireItem");
        waterItemNum = PlayerPrefs.GetInt("WaterItem");

        animalButtons = new List<Button> { deerButton, snailButton, squirrelButton, rabbitButton, foxButton, frogButton, owlButton, batButton };

        StartCoroutine(ActivateAnimalButtonsRandomly());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            showAdditionCanvas.SetActive(false);
        }

        isRainingInt = PlayerPrefs.GetInt("IsRain");

        if (isRainingInt == 1)
        {
            isRaining = true;
        }
        else
        {
            isRaining = false;
            frogButton.gameObject.SetActive(false);
            snailButton.gameObject.SetActive(false);
        }
    }

    IEnumerator ActivateAnimalButtonsRandomly()
    {
        while (true)
        {
            // Deactivate all animal buttons
            foreach (Button button in animalButtons)
            {
                button.gameObject.SetActive(false);
            }

            // Activate a random animal button
            Button randomButton = animalButtons[Random.Range(0, animalButtons.Count)];
            randomButton.gameObject.SetActive(true);
            if (randomButton == deerButton)
            {
                StartCoroutine(MoveDeer());
            }

            // Wait for a random interval before activating the next animal button
            yield return new WaitForSeconds(Random.Range(10f, 20f));
        }
    }

    public void AnimalClicked(Button animalButton, int firenum, int waternum)
    {
        animalButton.interactable = false;
        fireItemNum += firenum;
        waterItemNum += waternum;
        PlayerPrefs.SetInt("Coins", coinNum);
        PlayerPrefs.SetInt("FireItem", fireItemNum);
        PlayerPrefs.SetInt("WaterItem", waterItemNum);
        PlayerPrefs.Save();

        ShowAddition(firenum, waternum);
    }

    public void AnimalClickedDeer()
    {
        AnimalClicked(deerButton, 50, 50);
        PlayerPrefs.SetInt("DeerOn", 1);
        PlayerPrefs.Save();
        ShowAnimal(isDeerOn, deerSprite);
    }

    public void AnimalClickedSnail()
    {
        AnimalClicked(snailButton, 30, 30);
        PlayerPrefs.SetInt("SnailOn", 1);
        PlayerPrefs.Save();
        ShowAnimal(isSnailOn, snailSprite);
    }

    public void AnimalClickedSquirrel()
    {
        AnimalClicked(squirrelButton, 40, 40);
        PlayerPrefs.SetInt("SquirrelOn", 1);
        PlayerPrefs.Save();
        ShowAnimal(isSquirrelOn, squirrelSprite);
    }

    public void AnimalClickedRabbit()
    {
        AnimalClicked(rabbitButton, 40, 40);
        PlayerPrefs.SetInt("RabbitOn", 1);
        PlayerPrefs.Save();
        ShowAnimal(isRabbitOn, rabbitSprite);
    }

    public void AnimalClickedFox()
    {
        AnimalClicked(foxButton, 30, 30);
        PlayerPrefs.SetInt("FoxOn", 1);
        PlayerPrefs.Save();
        ShowAnimal(isFoxOn, foxSprite);
    }

    public void AnimalClickedFrog()
    {
        AnimalClicked(frogButton, 40, 40);
        PlayerPrefs.SetInt("FrogOn", 1);
        PlayerPrefs.Save();
        ShowAnimal(isFrogOn, frogSprite);
    }

    public void AnimalClickedOwl()
    {
        AnimalClicked(owlButton, 40, 40);
        PlayerPrefs.SetInt("OwlOn", 1);
        PlayerPrefs.Save();
        ShowAnimal(isOwlOn, owlSprite);
    }

    public void AnimalClickedBat()
    {
        AnimalClicked(batButton, 50, 50);
        PlayerPrefs.SetInt("BatOn", 1);
        PlayerPrefs.Save();
        ShowAnimal(isBatOn, batSprite);
    }

    public void ShowAddition(int fireNum, int waterNum)
    {
        showAdditionCanvas.SetActive(true);
        fireNumText.text = fireNum.ToString();
        waterNumText.text = waterNum.ToString();
    }

    public void ShowAnimal(bool isAnimalOn, Sprite animalSprite)
    {
        if (!isAnimalOn)
        {
            isAnimalOn = true;
            animalImage.sprite = animalSprite;
        }
    }

    IEnumerator MoveDeer()
    {
        deerButton.gameObject.transform.position = new Vector2(-10, deerButton.gameObject.transform.position.y);
        while (deerButton.gameObject.transform.position.x < 10)
        {
            Vector2 currentPositon = deerButton.gameObject.transform.position;
            deerButton.gameObject.transform.position = new Vector2(currentPositon.x + 0.01f, currentPositon.y);
            yield return null;
        }
    }
}
