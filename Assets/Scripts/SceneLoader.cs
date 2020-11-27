using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * 1. Handles Transition between game scenes
 * If we load the start scene, then we reset the state of the "Game".
 * the state of the game is held within "GameSession" objects,
 * note that this corresponds to the class name of script attached to a game object.
 *
 * 2. Quit Application
 * method to be linked to a button click to exit the application
 */

public class SceneLoader : MonoBehaviour
{

    private void LoadStartScence()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();

        if (gameSession != null)
        {
            gameSession.ResetGame();
        }
        
        SceneManager.LoadScene(0);
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int numberOfScenes = SceneManager.sceneCountInBuildSettings;
        
        if (currentSceneIndex ==  numberOfScenes - 1)
        {   // If this is last scene then cycle back to first start menu.
            LoadStartScence();
        }
        else
        {   
            // Load next scene using current scene index + 1
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        
    }
    
    // Quite application. Does not work while in Editor mode.
    public void QuitGame()
    {
        Application.Quit();
    }
}
