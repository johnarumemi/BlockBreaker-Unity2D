using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    // Configuration Parameters
    [Range(0.1f, 2f)][SerializeField] private float gameSpeed = 0.75f;
    [SerializeField] private int pointsPerBlockDestroyed = 83;

    [SerializeField] private TextMeshProUGUI scoreText;
    // state variables
    [SerializeField] private int currentScore = 0;

    private void Awake()
    { 
        // Implements Singleton Pattern to GameStatus
        
        // notice the plural of FindObject[s]OfType.
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        
        if (gameStatusCount > 1)
        {    // i.e if this Game Status instance is the Second One, destroy myself
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            // Do not destroy yourself when the next level loads in the future
            DontDestroyOnLoad(gameObject);
        }
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

        scoreText.text = currentScore.ToString();
    }
}
