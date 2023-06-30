using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatforms : MonoBehaviour
{
    private PlatformEffector2D effector;
    private bool fallThrough;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        fallThrough = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        fallThrough = false;
        effector.rotationalOffset = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && fallThrough)
        {
            effector.rotationalOffset = 180f;
            fallThrough = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && (fallThrough = false))
        {
            effector.rotationalOffset = 0;
            fallThrough = true;
        }
    }
}
