using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioMixerGroup MixerGroup;
    private float currentVolume = 0.4f;
    public Sound[] music;
    public Sound[] sfx;
    public Sound[] UIsfx;
    public AudioSource musicSource, sfxSource, uiSfx;


    private void Awake()
    {
        GetInstance();
    }

    private void OnEnable()
    {
        Actions.SfxPlay += PlaySFX;
        Actions.SoundPause += PauseMusicSfx;
    }

    private void OnDisable()
    {
        Actions.SfxPlay -= PlaySFX;
        Actions.SoundPause -= PauseMusicSfx;
    }

    private void GetInstance() 
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            DestroyObject(gameObject);
        }
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
            }
        }
    }

    /// <summary>
    /// method to pause all sound and sfx;
    /// </summary>
    public void PauseMusicSfx()
    {
        musicSource.mute = !musicSource.mute;
        sfxSource.mute = !sfxSource.mute;
        audioMixer.GetFloat("volume", out float volume);
        if (volume == +5f)
        {
            audioMixer.SetFloat("volume", -80f);
        }
        else
        {
            audioMixer.SetFloat("volume", +5f);
        }
    }

}
