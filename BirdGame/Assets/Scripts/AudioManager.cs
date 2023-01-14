using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Start()
    {
        musicSource.volume = PlayerPrefs.GetFloat("volumeMusic");
        sfxSource.volume = PlayerPrefs.GetFloat("volumeSFX");
    }

    public void PlayBackgroundMusic()
    {
        PlayMusic("BackgroundMusic");
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }
    
    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    
    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }
    
    public void StopBackgroundMusic()
    {
        musicSource.Stop();
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound sound = Array.Find(musicSounds, x => x.name == name);

        if (sound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = sound.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound sound = Array.Find(sfxSounds, x => x.name == name);
        if (sound == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.PlayOneShot(sound.clip);
        }
    }
}
