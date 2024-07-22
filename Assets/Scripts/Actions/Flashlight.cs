using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Flashlight : MonoBehaviour
{
    public Light flashlightLight; // Reference to the Light component
    private bool isFlashlightOn = false;

    void Start()
    {
        flashlightLight.enabled = isFlashlightOn;
    }

    public void Flip()
    {
        isFlashlightOn = !isFlashlightOn;
        flashlightLight.enabled = isFlashlightOn;
    }
}
