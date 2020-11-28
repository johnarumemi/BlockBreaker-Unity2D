using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 * Logic
 *
 * When Win Condition is met, uses SceneLoader to move to next Scene
 */


public class Level : MonoBehaviour
{
    // ------ Configuration Params ------
    
    // Serialized for debugging purposes only (we can see it)
    [SerializeField] private int breakableBlocks; 
    
    // Serialized to allow altering the Win Condition
    [SerializeField] private int winCondition; 
    
    // ------ Cached Component References ------
    private SceneLoader sceneLoader;
    
    // ================================================================
    private void Start()
    {
        winCondition = 0;
        
        // Calls a generic function if a particular Type of SceneLoader
        sceneLoader = FindObjectOfType<SceneLoader>(); 
    }
    
    public void AddBreakableBlock()
    {
        /*
         * this method is called by Blocks externally
         */
        breakableBlocks++;
    }
    
    public void DestroyBreakableBlock()
    {
        /*
         * This method is called by Blocks externally
         */
        
        // decrement number of breakable blocks within the level.
        breakableBlocks--;
        
        if(breakableBlocks <= winCondition)
        {
            // Win condition met, load next scene
            Debug.Log("CONGRATS! You Won!");
            sceneLoader.LoadNextScene();
        }
    }
    
}
