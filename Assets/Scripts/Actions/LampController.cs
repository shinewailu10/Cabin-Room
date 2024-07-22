using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LampController : MonoBehaviour
{
    public Light lampLight1;
    public Light lampLight2;
    private bool isOn = false;

    void Start()
    {
        lampLight1.enabled = isOn;
        lampLight2.enabled = isOn;

    }

    public void ToggleLight()
    {
        isOn = !isOn;
        lampLight1.enabled = isOn;
        lampLight2.enabled = isOn;

    }

 
}
