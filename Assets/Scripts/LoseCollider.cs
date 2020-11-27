using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseCollider : MonoBehaviour
{
   /*
    * Collider 2D with isTrigger = on
    *
    * This method is called on trigger of the attached 2D Collider
    * What is passed in is a reference to the 2D object that triggered event,
    * 
    */
   private void OnTriggerEnter2D(Collider2D other)
   {
       // Load Scene using String Reference
       SceneManager.LoadScene("X1. Game Over");
   }
}
