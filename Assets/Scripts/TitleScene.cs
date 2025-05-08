using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public GameObject blackimage;
    public GameObject sign;
    public float fadeDuration = 2.0f;

    private bool isSwitching = false;

    // Start is called before the first frame update
    void Start()
    {
        blackimage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isSwitching)
        {
            isSwitching = true;
            StartCoroutine(StartMovePauseImage());
            
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Menu");
    }

    private IEnumerator FadeOut()
    {
        Color color = spriteRenderer.color;
        float endcolor = color.a;

        for (float t = 0.0f; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            color.a = Mathf.Lerp(0, endcolor, normalizedTime);
            spriteRenderer.color = color;
            yield return null;
        }

        color.a = 1;
        StartGame();

    }


    IEnumerator StartMovePauseImage()
    {
        sign.transform.position = new Vector2(0, 0);
        Debug.Log(sign.transform.position.y);
        while (sign.transform.position.y < 10)
        {
            Vector2 currentPositon = sign.transform.position;
            sign.transform.position = new Vector2(currentPositon.x, currentPositon.y + 0.1f);
            yield return null;
        }
        blackimage.SetActive(true);
        StartCoroutine(FadeOut());
    }
}
