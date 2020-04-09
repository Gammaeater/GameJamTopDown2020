using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager2 : MonoBehaviour
{
    public static SoundManager2 instance;

    

    public AudioSource soundFX;
    void Awake()
    {
        instance = this;
       
    }

    
    void Update()
    {
        
    }

    public void PlaySoundFX(AudioClip clip)
    {
        soundFX.clip = clip;
        soundFX.Play();
    }
}
