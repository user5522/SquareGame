using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldESCToExit : MonoBehaviour {


    private float startTime = 0f;
    private float timer = 0f;
    public float holdTime = 3.0f;
 
    private bool held = false;
 
    public KeyCode Key = KeyCode.Escape;
   
    void Update () {
        if (Input.GetKeyDown(Key))
        {
            startTime = Time.time;
            timer = startTime;
        }
 
        if (Input.GetKey(Key) && held == false)
        {
            timer += Time.deltaTime;

            if (timer >= (startTime + holdTime))
            {
                held = true;
                Function();
            }
            if (Input.GetKeyUp(Key))
            {
            held = false;
            return;
            }
        }
 
    }

     void Function(){
         Debug.Log("exited");
         Application.Quit();
     }
}
