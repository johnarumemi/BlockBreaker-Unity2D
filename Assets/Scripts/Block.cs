using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
 * 1. On game start, registers itself to "Level"
 * 2. On collision with Ball, Destroy itself
 *    and remove / deregister itself from "Level"
 */

[RequireComponent(typeof(AudioSource))]
public class Block : MonoBehaviour
{
    // ------ Configuration Params ------
    [SerializeField] private AudioClip breakSound;
    
    // ------ Cached Component References ------
    private Level level;
    private GameSession gameSession;
    
    // ================================================================
    
    private void Start()
    {
        // Get Level gameObject and increment its No. Breakable Blocks
        level = FindObjectOfType<Level>();
        level.AddBreakableBlock();
        
        // GameSession Object, used for incrementing score
        gameSession = FindObjectOfType<GameSession>();
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {   
        // destroy "this" block
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        // Play sound at main camera
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        
        // Increment Score
        gameSession.AddToScore();
        
        // gameObject is 'this' object
        Destroy(gameObject);
        
        // calls LoadNextScene when number of blocks = 0
        level.DestroyBreakableBlock();
    }
}
