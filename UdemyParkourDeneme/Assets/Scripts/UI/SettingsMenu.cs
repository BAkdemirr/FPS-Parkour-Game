using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomix;

    private bool isFullscreen = true;

    public void SetResoulation(int index)
    {
        if (index == 0)
        {
            Screen.SetResolution(1920, 1080, isFullscreen);
        }else if (index == 1)
        {
            Screen.SetResolution(800, 800, isFullscreen);
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool fullcreen_Enable)
    {
        Screen.fullScreen = fullcreen_Enable;
        isFullscreen = fullcreen_Enable;
    }

    public void SetMouseSensitivity(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);
        if (GameObject.FindGameObjectWithTag("Player") != null) 
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mouseSensitivity = value;
        }
    }

    public void SetMasterVolume(float value)
    {
        audiomix.SetFloat("MasterVolume", value);
    }
    
    public void SetMusicVolume(float value)
    {
        audiomix.SetFloat("MusicVolume", value);
    }

}
