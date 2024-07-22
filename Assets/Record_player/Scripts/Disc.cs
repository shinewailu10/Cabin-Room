using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Disc : MonoBehaviour
{
    [Tooltip("The value at which the speed is applied")]
    [Range(0, 1)] public float sensitivity = 1.0f;

    [Tooltip("The max speed of the rotation")]
    public float speed = 10.0f;

    public bool isRotating = false;

    public AudioSource audioSource;


    public void SetIsRotating(bool value)
    {
        if (value)
        {
            Begin();
        }
        else
        {
            End();
        }
    }

    public void Begin()
    {
        isRotating = true;
    }

    public void End()
    {
        isRotating = false;
    }

    public void ToggleRotate()
    {
        isRotating = !isRotating;
    }


    public void SetSpeed(float value)
    {
        sensitivity = Mathf.Clamp(value, 0, 1);
        isRotating = (sensitivity * speed) != 0.0f;
    }

    private void Update()
    {
        if (isRotating)
            Rotate();
    }

    // Example method to play audio on some event, like a button press
    public void PlayAudioClip()
    {
        if (audioSource == null)
        {
            return;
        }

        if (audioSource.clip == null)
        {
            return;
        }

        audioSource.Play();

        if (!audioSource.isPlaying)
        {
            UnityEngine.Debug.LogError("AudioSource failed to play the clip.");
        }
    }

    // Method to stop the audio clip
    public void StopAudioClip()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        transform.Rotate(transform.up, (sensitivity * speed) * Time.deltaTime);
    }
}
