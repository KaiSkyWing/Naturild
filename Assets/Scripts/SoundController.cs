using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public AudioSource rainSound;
    public AudioSource fireSound;
    public AudioSource cricketSound;
    public AudioSource seaSound;
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

    public Slider bgmSlider;
    public Slider instrumentSlider;

    private List<AudioSource> bgmAudioSources;
    private Dictionary<AudioSource, float> bgmInitialVolumes;

    private List<AudioSource> instrumentAudioSources;
    private Dictionary<AudioSource, float> instrumentInitialVolumes;

    private bool isRaining;
    private static SoundController instance;
    private bool atShore = false;

    private float bgmVolume = 1.0f;
    private float instrumentVolume = 1.0f;

    void Awake()
    {
        // Ensure that only one instance of the SoundController exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist this object across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate SoundController objects
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetBGM();
        SetInstrument();
    }

    private void SetBGM()
    {
        bgmAudioSources = new List<AudioSource> { rainSound, fireSound, cricketSound, seaSound };
        bgmInitialVolumes = new Dictionary<AudioSource, float>();

        // Store the initial volumes
        foreach (AudioSource audioSource in bgmAudioSources)
        {
            bgmInitialVolumes[audioSource] = audioSource.volume;
        }
    }

    private void SetInstrument()
    {
        instrumentAudioSources = new List<AudioSource> { a, b, c, d, e, f, g, am, bm, cm, dm, em, fm, gm };
        instrumentInitialVolumes = new Dictionary<AudioSource, float>();

        // Store the initial volumes
        foreach (AudioSource audioSource in instrumentAudioSources)
        {
            instrumentInitialVolumes[audioSource] = audioSource.volume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWeatherState();
        PlaySounds();

        //Load();
    }

    private void Load()
    {
        if (!PlayerPrefs.HasKey("BGMVolume"))
        {
            PlayerPrefs.SetFloat(("BGMVolume"), 1);
        }
        if (!PlayerPrefs.HasKey("InstrumentVolume"))
        {
            PlayerPrefs.SetFloat(("InstrumentVolume"), 1);
        }

        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        instrumentSlider.value = PlayerPrefs.GetFloat("InstrumentVolume");
    }

    void UpdateWeatherState()
    {
        int isRainingInt = PlayerPrefs.GetInt("IsRain");

        isRaining = isRainingInt == 1;

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Cliff")
        {
            GoCliff();
        }
        else
        {
            LeaveCliff();
        }
    }

    private void UpdateBGMVolume()
    {
        foreach (AudioSource audioSource in bgmAudioSources)
        {
            audioSource.volume = instrumentInitialVolumes[audioSource] * bgmVolume;
        }

        PlayerPrefs.SetFloat(("BGMVolume"), bgmVolume);
    }

    private void UpdateInstrumentVolume()
    {
        foreach (AudioSource audioSource in instrumentAudioSources)
        {
            audioSource.volume = instrumentInitialVolumes[audioSource] * instrumentVolume;
        }
        PlayerPrefs.SetFloat(("InstrumentVolume"), instrumentVolume);
    }

    void PlaySounds()
    {
        if (atShore)
        {
            if (seaSound != null && !seaSound.isPlaying)
            {
                seaSound.Play();
            }
            rainSound.Stop();
            fireSound.Stop();
            cricketSound.Stop();
        }
        else if (isRaining)
        {
            if (rainSound != null && !rainSound.isPlaying)
            {
                rainSound.Play();
            }
            seaSound.Stop();
            fireSound.Stop();
            cricketSound.Stop();
        }
        else
        {
            if (fireSound != null && !fireSound.isPlaying)
            {
                fireSound.Play();
            }
            if (cricketSound != null && !cricketSound.isPlaying)
            {
                cricketSound.Play();
            }
            seaSound.Stop();
            rainSound.Stop();
        }
    }

    public void GoCliff()
    {
        atShore = true;
    }

    public void LeaveCliff()
    {
        atShore = false;
    }

    public void ChangeBGMVolume(float volume)
    {
        bgmVolume = volume;
        UpdateBGMVolume();
    }

    public void ChangeInstrumentVolume(float volume)
    {
        instrumentVolume = volume;
        UpdateInstrumentVolume();
    }
}
