using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchControl : MonoBehaviour
{

    private AudioSource source;
    private AudioClip clip;
    private bool on = false;
    private bool switchHit = false;
    private float switchRo = 5;
    private GameObject lightSwitch;






    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
     lightSwitch = transform.GetChild(1).gameObject;

    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
   
     if (switchHit == true)
     {
        source.PlayOneShot(clip);
        switchHit = false;
        on = !on;
       
     if (on == true)
     {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x + switchRo, transform.eulerAngles.y,transform.eulerAngles.z);

     }
     else{
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x - switchRo, transform.eulerAngles.y,transform.eulerAngles.z);

     }
     }

    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        XRBaseInteractor interactor = other.GetComponent<XRBaseInteractor>();
        if (interactor)
        {
            if (interactor.selectTarget)
            {
                switchHit = true; // Set switchHit to true when the interactor touches the switch
            }
        }
    }
}
