using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    // Configuration Parameters
    [Range(0.1f, 2f)][SerializeField] private float gameSpeed = 0.75f;
    [SerializeField] private int pointsPerBlockDestroyed = 83;
    
    // state variables
    [SerializeField] private int currentScore = 0;
    
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }
}
