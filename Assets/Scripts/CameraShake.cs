using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    // How long the object should shake for
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    // Reference to the Cinemachine Virtual Camera component
    public CinemachineVirtualCamera virtualCamera;

    // Original position and orientation of the Virtual Camera
    Vector3 originalPos;
    Quaternion originalRot;

    void OnEnable()
    {
        // Save the original position and orientation of the Virtual Camera
        originalPos = virtualCamera.transform.localPosition;
        originalRot = virtualCamera.transform.localRotation;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            // Modify the Virtual Camera's position and orientation to create a shake effect
            virtualCamera.transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            virtualCamera.transform.localRotation = new Quaternion(
                originalRot.x + Random.Range(-shakeAmount, shakeAmount) * .2f,
                originalRot.y + Random.Range(-shakeAmount, shakeAmount) * .2f,
                originalRot.z + Random.Range(-shakeAmount, shakeAmount) * .2f,
                originalRot.w + Random.Range(-shakeAmount, shakeAmount) * .2f);

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            // Reset the Virtual Camera's position and orientation
            virtualCamera.transform.localPosition = originalPos;
            virtualCamera.transform.localRotation = originalRot;
        }
    }
}
