using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/*
 * 1. At start, locks ball to Paddle
 * 2. On LMB click, launches ball
 * 3. On collision with a Lose collider, plays a random audio clip
 */
public class Ball : MonoBehaviour
{
    // ------ Configuration Params ------
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds;
    
    private bool launched = false;
    
    // ------ Cached Component References ------
    
    // Audio Source is what plays AudioClip
    private AudioSource myAudioSource;
    
    // state
    private Vector2 paddleToBallVector;
    
    // ================================================================
    
    void Start()
    {
        if (paddle1 is null) paddle1 = FindObjectOfType<Paddle>();
        
        myAudioSource = GetComponent<AudioSource>(); // Cache this for later use
        paddleToBallVector = transform.position - paddle1.transform.position; // start datum for locking
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched)
        {
            // stop launch and locking if ball is already launched.
            LaunchOnMouseClick();
            LockBallToPaddle();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            launched = true;
            
            // Apply velocity to "this" Ball via its RigidBody2D component
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            
        }
    }

    private void LockBallToPaddle()
    {
        // Current position of paddle
        if (!launched)
        {
            Vector2 paddlePosition = new Vector2(
            paddle1.transform.position.x,
            paddle1.transform.position.y
            );

            transform.position = paddlePosition + paddleToBallVector;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        /*
         * Play Sound Effect
         * - Only play if game has started and if we have NOT collided with a gameObject
         *   whose name contains "lose" i.e. the Lose Collider gameObject
         */
        if (launched && !other.gameObject.name.ToLower().Contains("lose"))
        {
            // Get Random AudioClip from the SerializedField variable
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            
            // Play Clip
            myAudioSource.PlayOneShot(clip);
        }
    }
}
