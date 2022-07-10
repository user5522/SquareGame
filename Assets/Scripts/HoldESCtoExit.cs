using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldESCToExit : MonoBehaviour {

   // Timer controls
    private float startTime = 0f;
    private float timer = 0f;
    public float holdTime = 4.5f;
 
    private bool held = false;
 
    public KeyCode Key = KeyCode.Escape;
   
    void Update ()
    {
        if (Input.GetKeyDown(Key))
        {
            startTime = Time.time;
            timer = startTime;
        }
 
        // Adds time onto the timer so long as the key is pressed
        if (Input.GetKey(Key) && held == false)
        {
            timer += Time.deltaTime;
 
            // Once the timer float has added on the required holdTime, changes the bool (for a single trigger), and calls the function
            if (timer >= (startTime + holdTime))
            {
                held = true;
                Function();
            }
        }
 
        // For single effects. Remove if not needed
        if (Input.GetKeyUp(Key))
        {
            held = false;
        }
    }
 
    // Method called after held for required time
    void Function()
    {
        Debug.Log("works");
        Application.Quit();
    }
}
