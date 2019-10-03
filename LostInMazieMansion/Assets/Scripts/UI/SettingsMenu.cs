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
}
