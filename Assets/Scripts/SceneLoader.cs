using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log($"current index {currentSceneIndex} and buildCount {SceneManager.sceneCountInBuildSettings}");
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {   // If this is last scene then cycle back to first start menu.
            SceneManager.LoadScene(0);
        }
        else
        {    Debug.Log($"Loading Scence : {currentSceneIndex + 1}");
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
