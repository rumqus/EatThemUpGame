using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] music;
    public AudioSource[] sfx;
    public AudioSource musicSource, sfxSource;


    private void Awake()
    {

        
    }

    private void GetInstance() 
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayMainTheme();
    }

    /// <summary>
    /// method of playing main theme of the game;
    /// </summary>
    private void PlayMainTheme() 
    {
        
        Sound s = music[UnityEngine.Random.Range(0, music.Length)];
        musicSource.clip = s.clip;
        musicSource.Play();
    }

    /// <summary>
    /// method to all sound and sfx;
    /// </summary>
    public void PauseMusicSfx() 
    {
        musicSource.mute = !musicSource.mute;
        foreach (AudioSource item in sfx)
        {
            item.mute = !item.mute;
        }
    }

}
