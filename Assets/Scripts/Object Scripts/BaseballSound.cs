using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballSound : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip ballBounce;

    // Minimum velocity to trigger sound collision
    public float minCollisionVelocity = 0.5f;
    private bool canPlaySound = false;

    void Start()
    {
        // Delay sound activation for 0.5s
        StartCoroutine(EnableSoundAfterDelay(0.5f));
    }

    IEnumerator EnableSoundAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canPlaySound = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (canPlaySound && collision.relativeVelocity.magnitude > minCollisionVelocity)
        {
            // Adjust volume scale
            audioPlayer.PlayOneShot(ballBounce, 0.7f);
        }
    }
}
