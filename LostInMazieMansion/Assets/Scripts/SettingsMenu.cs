using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    /*
     * This method changes the volume based on the volume slider.
     */
	public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume); // changes volume to float value 
    }

    /*
     * This method changes the quality of the game based on the argument given in the drop down tab. 
     */
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); // changes quality
    }

    /*
     * This method toggles fullscreen by clicking the toggle button
     */
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; // changes fullscreen to boolean
    }
}
