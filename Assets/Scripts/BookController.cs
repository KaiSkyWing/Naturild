using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BookController : MonoBehaviour
{
    public Image deer, snail, squirrel, rabbit, fox, frog, owl, bat;

    private int deerOn, snailOn, squirrelOn, rabbitOn, foxOn, frogOn, owlOn, batOn;

    // Start is called before the first frame update
    void Start()
    {
        deerOn = PlayerPrefs.GetInt("DeerOn");
        snailOn = PlayerPrefs.GetInt("SnailOn");
        squirrelOn = PlayerPrefs.GetInt("SquirrelOn");
        rabbitOn = PlayerPrefs.GetInt("RabbitOn");
        foxOn = PlayerPrefs.GetInt("FoxOn");
        frogOn = PlayerPrefs.GetInt("FrogOn");
        owlOn = PlayerPrefs.GetInt("OwlOn");
        batOn = PlayerPrefs.GetInt("BatOn");

        CheckAnimalOn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CheckAnimalOn()
    {
        if (deerOn == 0)
        {
            SetImageToBlack(deer);
        }

        if (snailOn == 0)
        {
            SetImageToBlack(snail);
        }

        if (squirrelOn == 0)
        {
            SetImageToBlack(squirrel);
        }

        if (rabbitOn == 0)
        {
            SetImageToBlack(rabbit);
        }

        if (foxOn == 0)
        {
            SetImageToBlack(fox);
        }

        if (frogOn == 0)
        {
            SetImageToBlack(frog);
        }

        if (owlOn == 0)
        {
            SetImageToBlack(owl);
        }

        if (batOn == 0)
        {
            SetImageToBlack(bat);
        }
    }

    private void SetImageToBlack(Image img)
    {
        img.color = Color.black;
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }
}
