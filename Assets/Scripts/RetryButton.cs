using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{

    public Button retryButton;

    // Start is called before the first frame update
    void Start()
    {
        VisibleButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InvisibleButton()
    {
        retryButton.interactable = false;
    }

    public void VisibleButton()
    {
        retryButton.interactable = true;
    }

    public void RetryAndGoBackHome()
    {
        InvisibleButton();
        SceneManager.LoadScene("Title");
    }
}
