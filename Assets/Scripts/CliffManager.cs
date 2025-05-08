using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CliffManager : MonoBehaviour
{
    public Animator guitarAnimator;

    private HashSet<KeyCode> guitarKeys = new HashSet<KeyCode>
    {
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaySounds();
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PlayingGuitar(bool isPlaying)
    {
        guitarAnimator.SetBool("IsPlaying", isPlaying);
    }

    private void PlaySounds()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in guitarKeys)
            {
                if (Input.GetKeyDown(key))
                {
                    StartCoroutine(AnimateGuitar());
                    break;
                }
            }
        }

    }

    IEnumerator AnimateGuitar()
    {
        PlayingGuitar(true);
        yield return new WaitForSeconds(0.3f);
        PlayingGuitar(false);
    }
}
