using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeInEffect : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject blackimage;
    public Canvas menuCanvas;

    public float fadeDuration = 1.0f;

    void Start()
    {
        StartFadeOut();
    }

    public void StartFadeOut()
    {
        blackimage.SetActive(true);
        StartCoroutine(FadeOut());
        
    }

    private IEnumerator FadeOut()
    {
        Color color = spriteRenderer.color;
        float startcolor = color.a;

        for (float t = 0.0f; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            color.a = Mathf.Lerp(startcolor, 0, normalizedTime);
            spriteRenderer.color = color;
            yield return null;
        }

        color.a = 0;
        blackimage.SetActive(false);
        menuCanvas.gameObject.SetActive(true);
    }
}