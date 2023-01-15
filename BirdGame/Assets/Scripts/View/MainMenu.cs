using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
   private Resolution[] resolutions;
   public Dropdown resolutionDropdown;
   private void Start()
   {
      resolutions = Screen.resolutions;
      resolutionDropdown.ClearOptions(); // null reference
      List<string> options = new List<string>();
      int currentResolutionIndex = 0;
      for (int i = 0; i < resolutions.Length; i++)
      {
         string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate +"Hz";
         options.Add(option);
         
         if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
         {
            currentResolutionIndex = i;
         }
      }
      resolutionDropdown.AddOptions(options);
      resolutionDropdown.value = currentResolutionIndex;
      resolutionDropdown.RefreshShownValue();
   }

   public void PlayEasyGame()
   {
      SceneManager.LoadScene("GameEasyScene");
   }
   
   public void PlayHardGame()
   {
      SceneManager.LoadScene("GameHardScene");
   }
   
   public void QuitGame()
   {
      Application.Quit();
   }

   public void SetFullScreen(bool isFullScreen)
   {
      Screen.fullScreen = isFullScreen;
   }
   
   public void SetResolution(int resolutionIndex)
   {
      Resolution resolution = resolutions[resolutionIndex];
      Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
   }
}
