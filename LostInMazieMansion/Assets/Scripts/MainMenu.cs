using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    /*
     * This method moves to the next scene when the play button is clicked which is the game.
     */
	public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // moves to next scence (the game)
    }

    /*
     * This method exits the application after quit and yes are selected.
     */
    public void QuitGame()
    {
        Debug.Log("Quit"); // messages console that the application quit
        Application.Quit(); // exits application
    }
}
