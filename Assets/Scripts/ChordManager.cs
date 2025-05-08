using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChordManager : MonoBehaviour
{
    public AudioSource a;
    public AudioSource b;
    public AudioSource c;
    public AudioSource d;
    public AudioSource e;
    public AudioSource f;
    public AudioSource g;
    public AudioSource am;
    public AudioSource bm;
    public AudioSource cm;
    public AudioSource dm;
    public AudioSource em;
    public AudioSource fm;
    public AudioSource gm;

    private List<AudioSource> audioSources;

    // Start is called before the first frame update
    void Start()
    {
        audioSources = new List<AudioSource> { a, b, c, d, e, f, g, am, bm, cm, dm, em, fm, gm };
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Cliff")
        {
            PlaySounds();
        }
    }

    private void PlaySounds()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DetectMinor(a, am);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            DetectMinor(b, bm);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            DetectMinor(c, cm);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            DetectMinor(d, dm);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            DetectMinor(e, em);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            DetectMinor(f, fm);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            DetectMinor(g, gm);
        }

    }

    public void StopAll()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }

    public void DetectMinor(AudioSource major, AudioSource minor)
    {
        StopAll();
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            minor.Play();
        }
        else
        {
            major.Play();
        }
    }
}