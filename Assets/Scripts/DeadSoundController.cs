using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSoundController : MonoBehaviour
{
    public AudioSource deadSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlaySound()
    {
        Debug.Log("aaa");
        deadSound.Play();
    }
}
