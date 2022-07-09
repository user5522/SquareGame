using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldESCtoExit : MonoBehaviour {

    public float startTime = 0f;
    public float randomTime = 0f;
    public float holdTime = 5.0f;
     
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            randomTime = Time.time;
            if (startTime + holdTime <= Time.time) {
                Debug.Log("exit"); // this is for testing purposes
                Application.Quit();
                }
        }
    }
} 
