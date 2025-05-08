 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public Text timeText;
    public Text levelText;
    public float remainingTime;
    public ClearEffect clearEffect;
    public PlayerController playerController;

    private bool isAlive; 
    private bool isClear;

    // Start is called before the first frame  update
    void Start() 
    {   
        remainingTime =   90.00f;
        isAlive = true;
        isClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            remainingTime -= Time.deltaTime;
            timeText.text = (remainingTime.ToString("F0"));
            levelText.text = ("level: " + playerController.level.ToString());


            if (remainingTime <= 0 && isClear == false)
            {
                clearEffect.GameClear();
                isClear = true;
            }
        }
    }

    public void StopCounting()
    {
        isAlive = false;
    }
    public void StartCounting()
    {
        isAlive = true;
    }
}
