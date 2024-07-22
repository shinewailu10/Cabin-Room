using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine.XR.Interaction.Toolkit;

public class RecordPlayer : MonoBehaviour {

    public bool recordPlayerActive = false; // Flag if the record player is active
    public RotateObject socket; // To rotate the disc using socket
    public XRSocketInteractor socketInteractor;
    public Disc disc;

    public Disc disc1;
    public Disc disc2;
    public Disc disc3;
    public Disc disc4;

    private GameObject _arm;

    public int mode; // The mode which our record player is in. 0 for inactive, 1 for activation, 2 for running the music, 3 for stopping
    private float _armAngle;
    private bool _isPlaying = false;

    private void Awake()
    {
        _arm = gameObject.transform.Find("arm").gameObject;
    }

    public void Play(string s)
    {
        if (s == "disc")
        {
            disc = disc1;
        }
        else if (s == "disc2")
        {
            disc = disc2;
        }
        else if (s == "disc3")
        {
            disc = disc3;
        }
        else if (s == "disc4")
        {
            disc = disc4;
        }
        recordPlayerActive = true;
    }

    public void Stop()
    {
        Debug.Log("Stop");
        recordPlayerActive = false;
        mode = 3;
    }

    private void Start()
    {
        mode = 0;
        _armAngle = 0.0f;
    }

    private void Update()
    {
        //-- Mode 0: player off
        if (mode == 0)
        {
            if (recordPlayerActive == true)
                mode = 1;
        }
        //-- Mode 1: activation
        else if (mode == 1)
        {
            if (recordPlayerActive == true)
            {
                _armAngle += Time.deltaTime * 30.0f;
                if (_armAngle >= 30.0f)
                {
                    _armAngle = 30.0f;
                    mode = 2;
                }
            }
            else
                mode = 3;
        }
        //-- Mode 2: running
        else if (mode == 2)
        {
            if (recordPlayerActive == true)
            {
                if (!_isPlaying)
                {
                    disc.PlayAudioClip();
                    _isPlaying = true;
                }
                if (!disc.audioSource.isPlaying)
                {
                    recordPlayerActive = false;
                    mode = 3;
                }
                socket.Begin();
            }
            else
                mode = 3;
        }
        //-- Mode 3: stopping
        else
        {
            if (recordPlayerActive == false)
            {
                _armAngle -= Time.deltaTime * 30.0f;
                if (_armAngle <= 0.0f)
                {
                    _armAngle = 0.0f;
                }
                if (disc != null)
                {
                    disc.StopAudioClip();
                }
                _isPlaying = false;
                socket.End();
                disc = null;
            }
            else
                mode = 1;
        }

        //-- update objects
        _arm.transform.localEulerAngles = new Vector3(0.0f, _armAngle, 0.0f);
    }
}
