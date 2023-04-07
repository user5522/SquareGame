using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 1f;

    private Vector3 startPosition;
    private bool movingToTarget = true;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (movingToTarget)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                speed * Time.deltaTime
            );

            if (transform.position == targetPosition)
            {
                movingToTarget = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                startPosition,
                speed * Time.deltaTime
            );

            if (transform.position == startPosition)
            {
                movingToTarget = true;
            }
        }
    }
}
