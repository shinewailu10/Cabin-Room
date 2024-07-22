using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecordPlayerSystem : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;

    private IXRSelectInteractable currentHeldObject;

    public RecordPlayer rp;
    // Start is called before the first frame update
    void OnEnable()
    {
        if (socketInteractor == null)
        {
            socketInteractor = GetComponent<XRSocketInteractor>();
        }

        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.AddListener(OnSelectEntered);
            socketInteractor.selectExited.AddListener(OnSelectExited);
        }
    }

    void OnDisable()
    {
        if (socketInteractor != null)
        {
            socketInteractor.selectEntered.RemoveListener(OnSelectEntered);
            socketInteractor.selectExited.RemoveListener(OnSelectExited);
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        currentHeldObject = args.interactableObject;
        rp.Play(currentHeldObject.transform.gameObject.name);
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        currentHeldObject = null;
    }

    public IXRSelectInteractable GetCurrentHeldObject()
    {
        return currentHeldObject;
    }

    void Update()
    {
      
    }
}
