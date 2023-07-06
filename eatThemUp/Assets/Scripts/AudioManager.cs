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
    public void PauseMusicSfx()
    {
        musicSource.mute = !musicSource.mute;
        sfxSource.mute = !sfxSource.mute;


        //MixerGroup.audioMixer.SetFloat("volume", -80f);
        //Debug.Log($@"Volume_start_{volume}");
        //audioMixer.SetFloat("volume", -80f);
        audioMixer.GetFloat("volume", out float volume);
        if (volume == 0f)
        {
            audioMixer.SetFloat("volume", -80f);
        }
        else
        {
            audioMixer.SetFloat("volume", 0f);
        }
        Debug.Log($@"Volume_end_{volume}");
    }

    //public void GetPooledSoundsPause(List<GameObject> listPooled) 
    //{
    //    foreach (var item in listPooled)
    //    {
    //        if (item.TryGetComponent<AudioSource>(out AudioSource audioItem)) 
    //        {
    //            audioItem.mute = !audioItem.mute;
    //        }
    //    }
    
    //}

}
