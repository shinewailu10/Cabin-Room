using UnityEngine;

public class FanController : MonoBehaviour
{
    public float maxSpeed = 600.0f;
    public float accelerationRate = 20.0f;
    public float decelerationRate = 20.0f;

    private bool isOn = false;
    private float currentSpeed = 0.0f;

    void Update()
    {
        if (isOn && currentSpeed < maxSpeed)
        {
            // Gradually increase speed
            currentSpeed += accelerationRate * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0.0f, maxSpeed);
        }
        else if (!isOn && currentSpeed > 0.0f)
        {
            // Gradually decrease speed
            currentSpeed -= decelerationRate * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0.0f, maxSpeed);
        }

        // Apply rotation based on current speed
        transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
    }

    public void ToggleFan()
    {
        isOn = !isOn;

     

    }
    public void TurnOn()
    {
        isOn = true;


    }

    public void TurnOff()
    {
        isOn = false;
    }


}
