using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightControl : MonoBehaviour
{
    public Light lighting;
    private bool isOn = false;

    void Start()
    {
        lighting.enabled = isOn;
    }

    public void ToggleLight()
    {
        isOn = !isOn;
        lighting.enabled = isOn;
    }

 
}
