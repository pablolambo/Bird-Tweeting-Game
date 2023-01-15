using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    public Toggle musicToggle, sfxToggle;
    
    private float musicVolumePrefs, sfxVolumePrefs;
    private int toggleMusicPrefs, toggleSfxPrefs;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        toggleMusicPrefs = AudioManager.Instance.musicSource ? 1 : 0;
    }
    public void ToggleSfx()
    {
        AudioManager.Instance.ToggleSFX();
        toggleSfxPrefs = AudioManager.Instance.sfxSource ? 1 : 0;
    }


    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(musicSlider.value);
    }
    public void SfxVolume()
    {
        AudioManager.Instance.SfxVolume(sfxSlider.value);
    }

    public void SaveVolumeButton()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);

        PlayerPrefs.Save();
        LoadValues();
    }

    private void LoadValues()
    {
        UpdateCheckboards();
        UpdateSlider();
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume");
        AudioListener.volume = musicSlider.value;
    }
    
    public void UpdateCheckboards()
    {
        musicToggle.isOn = AudioManager.Instance.musicSource;
        sfxToggle.isOn = AudioManager.Instance.sfxSource;
    }
    
    public void UpdateSlider()
    {
        musicSlider.value = AudioManager.Instance.musicSource.volume;
        sfxSlider.value = AudioManager.Instance.sfxSource.volume;
    }
}
