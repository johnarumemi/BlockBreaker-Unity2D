using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    // ------ Configuration Params ------
    [Range(0.1f, 2f)][SerializeField] private float gameSpeed = 0.75f;
    [SerializeField] private int pointsPerBlockDestroyed = 83;

    [SerializeField] private TextMeshProUGUI scoreText;
    
    // state variables
    [SerializeField] private int currentScore = 0;
    
    // ================================================================
    
    private void Awake()
    { 
        /*
         * Implements Singleton Pattern to GameSession
         */
        
        // notice the plural of FindObject[s]OfType.
        int gameSessionCount = FindObjectsOfType<GameSession>().Length;
        
        if (gameSessionCount > 1)
        {    // i.e if this GameSession instance is the Second One, destroy myself
            ResetGame();
        }
        else
        {
            // Do not destroy yourself when the next level/Scene loads in the future
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetGame()
    {
        // make this to inactive so other scripts that need it wont end up using it
        gameObject.SetActive(false); 
        
        Destroy(gameObject);
    }
    
    // Update is called once per frame
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        
        // Update the Score Text Game Object's text field
        scoreText.text = currentScore.ToString();
    }
}
