using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = System.Random;

public class Ball : MonoBehaviour
{
    // config params
    [SerializeField] private Paddle paddle1;
    [SerializeField] private float xPush = 2f;
    [SerializeField] private float yPush = 15f;
    [SerializeField] private AudioClip[] ballSounds;
    
    private bool launched = false;
    // cached component references
    private AudioSource myAudioSource;
    
    // state
    private Vector2 paddleToBallVector;
    
    void Start()
    {
        if (paddle1 is null) paddle1 = FindObjectOfType<Paddle>();
        
        myAudioSource = GetComponent<AudioSource>();
        paddleToBallVector = transform.position - paddle1.transform.position;
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
            // want to "push" the ball
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
        // Play Sound Effect
        if (launched && !other.gameObject.name.ToLower().Contains("lose"))
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }
    }
}
