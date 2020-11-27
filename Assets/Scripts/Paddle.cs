using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    /*
     * configuration parameters
     *
     * used to assist us in clamping the paddles location in X-direction.
     */   
    [SerializeField] private float screenWidthInUnits = 16f;
    
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;
    // Update is called once per frame
    void Update()
    {
        // Current mouse x-coordinate in unity World Units
        float mousePosInUnits = (Input.mousePosition.x / Screen.width) * screenWidthInUnits;
        
        // Current Position Vector in absolute coordinates
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        
        // Set X-coordinate in Unity World Units and Clamp to within specified range
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);

        // Move the current object this script is attached to, to the specified unity world units coordinates
        transform.position = paddlePos;
    }
}
