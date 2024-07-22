using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateReticle : MonoBehaviour
{
    public float minSize = 1.0f;
    public float maxSize = 2.0f;
    private string direc = "Increase";
    public float incrementPerSec = 0.2f;
    public GameObject reticle;

    // Update is called once per frame
    void Update()
    {
        float scaleX = reticle.transform.localScale.x;
        float scaleZ = reticle.transform.localScale.z;
        float sizeChange = incrementPerSec * Time.deltaTime;
        //Debug.Log("scaleX is " + scaleX + ", scaleZ is " + scaleZ +  ", direc is " + direc);

        if (scaleX <= minSize)
        {
            direc = "Increase";
        }
        else if (scaleX >= maxSize)
        {
            direc = "Decrease";
        }

        if (direc == "Increase")
        {
            reticle.transform.localScale = new Vector3(scaleX + sizeChange, 1.0f, scaleZ + sizeChange);
        }
        else if (direc == "Decrease")
        {
            reticle.transform.localScale = new Vector3(scaleX - sizeChange, 1.0f, scaleZ - sizeChange);
        }
    }
}
