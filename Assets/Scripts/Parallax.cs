using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float startpos, length;
    public GameObject cam;
    public float parallaxIntensity;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxIntensity));
        float distance = (cam.transform.position.x * parallaxIntensity);
        transform.position = new Vector3(startpos + distance, transform.position.y, transform.position.z);

        if (temp > startpos + length) {
            startpos += length;
        } else if (temp < startpos - length) {
            startpos -= length;
        }
    }
}
