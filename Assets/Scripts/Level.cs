using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] private int breakableBlocks; // Serialized for debugging purposes only (we can see it)
    [SerializeField] private int winCondition;
    
    private SceneLoader sceneLoader;

    private void Start()
    {
        winCondition = 0;
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    
    public void AddBreakableBlock()
    {
        breakableBlocks++;
    }
    
    public void DestroyBreakableBlock()
    {
        breakableBlocks--;
        
        if(breakableBlocks <= winCondition)
        {
            Debug.Log("CONGRATS! You Won!");
            sceneLoader.LoadNextScene();
        }
    }
    
}
