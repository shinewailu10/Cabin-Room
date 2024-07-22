using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTilt : MonoBehaviour
{
    public Transform spout;
    public ParticleSystem waterParticles;
    public AudioSource pouringSound;
    public float tiltThreshold = 70f; // Adjust this to set the tilt angle threshold

    private bool isPouring = false;

    void Update()
    {
        // Calculate the tilt angle between the world up vector and the spout's forward vector
        float tiltAngle = Vector3.Angle(Vector3.up, spout.forward);

        if (tiltAngle > tiltThreshold && !isPouring)
        {
            StartPouring();
        }
        else if (tiltAngle <= tiltThreshold && isPouring)
        {
            StopPouring();
        }
    }

    void StartPouring()
    {
        isPouring = true;
        waterParticles.Play();
        pouringSound.Play();
    }

    void StopPouring()
    {
        isPouring = false;
        waterParticles.Stop();
        pouringSound.Stop();
    }
}