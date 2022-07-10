using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldESCToExit : MonoBehaviour {

    public Animator transition;

   // Timer controls
    private float startTime = 0f;
    private float timer = 0f;
    public float holdTime = 3.5f;
 
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
            Function();
            // return;
            }
        }
 
    }

    void Function(){
        Debug.Log("exited");
        Application.Quit();
    }

//     void Function() {
//         StartCoroutine(Animation());
//     }
//     IEnumerator Animation() {
//         transition.SetTrigger("Start");
//         yield return new WaitForSeconds(holdTime);
//         Debug.Log("exited"); //this is for testing purposes
//         Application.Quit();
//     }
// }
