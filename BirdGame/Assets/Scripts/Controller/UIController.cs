using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider musicSlider, sfxSlider;
    private float musicVolumePrefs, sfxVolumePrefs;

    void Awake() 
     { 
         musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
         sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
     }

    private void Update()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
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

    public void LoadValues()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 0.5f);
    }
}
