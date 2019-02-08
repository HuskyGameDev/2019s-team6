using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool IsGamePaused = false;
    public GameObject pauseMenuUI;

	// Update is called once per frame
	void Update () {

        // if 'ESC' key is pressed while running
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // if the game is paused
            if (IsGamePaused)
            {
                Resume(); // call resume function
            }
            // otherwise
            else
            {
                Pause(); // call pause function
            }
        }
	}

    /*
     * This method deactiveates the pause menu, resumes the game, and returns the message 'Resume' to console.
     */
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // deactivate gameObject PauseMenu
        Time.timeScale = 1f; // start game time
        IsGamePaused = false; // cahnge boolean to false
        Debug.Log("Resume"); // message console
    }

    /*
     * This method activates the pause menu, stops the game, and returns the message 'Pause' to console.
     */
    void Pause()
    {
        pauseMenuUI.SetActive(true); // activate gameObject PauseMenu
        Time.timeScale = 0f; // stop game time
        IsGamePaused = true; // change boolean to true
        Debug.Log("Pause"); // message console
    }
}
