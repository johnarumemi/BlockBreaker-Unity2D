using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // configuration parameters   
    [SerializeField] private float screenWidthInUnits = 16f;

    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    // Update is called once per frame
    void Update()
    {
        
        float mousePosInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        
        // Current Position
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        // Move in X direction
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);

        // Move the current object this script is attached to
        transform.position = paddlePos;
    }
}
