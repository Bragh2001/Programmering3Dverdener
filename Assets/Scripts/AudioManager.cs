using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public AudioSource PlayerSource;
    public AudioClip WalkingClip;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            PlayerSource.PlayOneShot(WalkingClip);
        }

    }
}
