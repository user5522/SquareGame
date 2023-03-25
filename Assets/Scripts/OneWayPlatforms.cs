using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatforms : MonoBehaviour
{
    private PlatformEffector2D effector;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            effector.rotationalOffset = 180f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            effector.rotationalOffset = 0;
        }
    }
}
