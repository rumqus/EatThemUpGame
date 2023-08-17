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
        Actions.StopOnce += StopOnce;
    }

    private void OnDisable()
    {
        Actions.SfxPlay -= PlaySFX;
        Actions.SoundPause -= PauseMusicSfx;
        Actions.StopOnce -= StopOnce;

    }

    /// <summary>
    /// method prevents copying audiomanager on restarting scene
    /// </summary>
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
        PauseMusicSfx();
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
    /// method of playing SFX
    /// </summary>
    /// <param name="name"></param>
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
        if (volume  == +4f)
        {
            audioMixer.SetFloat("volume", -80f);
        }
        else
        {
            audioMixer.SetFloat("volume", +4f);
        }
    }

    public void StopOnce()
    {
        musicSource.mute = true;
        sfxSource.mute = true;
        audioMixer.SetFloat("volume", -80f);
    }

}
