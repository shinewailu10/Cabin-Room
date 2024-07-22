using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRControllerInputHandler : MonoBehaviour
{
    public InputActionReference triggerAction; // Reference to the trigger action
    public AudioClip click; // Reference to the audio clip

    private AudioSource audioSource; // Reference to the AudioSource component
    private XRGrabInteractable grabbedFlashlight;

    void Awake()
    {
        // Add or get the AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnEnable()
    {
        triggerAction.action.performed += OnTriggerPressed;
        triggerAction.action.Enable();
    }

    void OnDisable()
    {
        triggerAction.action.performed -= OnTriggerPressed;
        triggerAction.action.Disable();
    }

    void OnTriggerPressed(InputAction.CallbackContext context)
    {
        if (grabbedFlashlight != null)
        {
            Flashlight flashlightController = grabbedFlashlight.GetComponent<Flashlight>();
            if (flashlightController != null)
            {
                flashlightController.Flip();
                PlayClickSound();
            }
        }
    }

    void PlayClickSound()
    {
        if (click != null)
        {
            audioSource.clip = click;
            audioSource.Play();
        }
    }

    public void OnSelectEntered(XRBaseInteractor interactor)
    {
        grabbedFlashlight = interactor.GetOldestInteractableSelected() as XRGrabInteractable;
    }

    public void OnSelectExited(XRBaseInteractor interactor)
    {
        grabbedFlashlight = null;
    }
}
