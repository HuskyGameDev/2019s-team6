/*
 * Holds information about the game.  Alway present.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // the background music track
    private AudioSource backgroundMusic;

    private void Start()
    {
        // get the background music component
        backgroundMusic = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        // if the music isn't playing, play the music
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

}
