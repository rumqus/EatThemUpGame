using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] music;
    public Sound[] sfx;
    //public AudioSource[] sfx;
    public AudioSource musicSource, sfxSource;



    private void Awake()
    {
        GetInstance();
    }

    private void OnEnable()
    {
        Actions.SfxPlay += PlaySFX;
    }

    private void OnDisable()
    {
        Actions.SfxPlay -= PlaySFX;
    }

    private void GetInstance() 
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //PlayMainTheme();
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

    private void PlaySFX(string name) 
    {
        Sound s;
        for (int i = 0; i < sfx.Length; i++)
        {
            if (sfx[i].name == name)
            {
                s = sfx[i];
                sfxSource.clip = s.clip;
                sfxSource.Play();
                Debug.Log(s.name);
            }
        }
    }

    /// <summary>
    /// method to all sound and sfx;
    /// </summary>
    //public void PauseMusicSfx() 
    //{
    //    musicSource.mute = !musicSource.mute;
    //    foreach (AudioSource item in sfx)
    //    {
    //        item.mute = !item.mute;
    //    }
    //}

}
