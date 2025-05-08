using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOutEffect : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject blackimage;
    public ClearEffect clearEffect;
    public float fadeDuration = 2.0f;

    void Start()
    {
        blackimage.SetActive(false);
    }

    public void StartFadeOut()
    {
        blackimage.SetActive(true);
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Color color = spriteRenderer.color;
        float  endcolor = color.a;

        for (float t = 0.0f; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            color.a = Mathf.Lerp(0, endcolor, normalizedTime);
            spriteRenderer.color = color;
            yield return null;
        }

        color.a = 1;
        clearEffect.GameOver();
    }
}
