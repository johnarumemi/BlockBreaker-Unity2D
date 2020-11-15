using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    
    // Cached references
    private Level level;
    private GameStatus gameStatus;
    
    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.AddBreakableBlock();

        gameStatus = FindObjectOfType<GameStatus>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        // This creates an audio source and plays it once and destroys it.

        // Play sound at main camera
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        
        
        gameStatus.AddToScore();
        
        // gameObject is 'this' object
        Destroy(gameObject);
        
        // calls LoadNextScence when number of blocks = 0
        level.DestroyBreakableBlock();
    }
}
