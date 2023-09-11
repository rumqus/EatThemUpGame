using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMusic : MonoBehaviour
{
    private GameObject audiomanage;

    // Start is called before the first frame update
    void Start()
    {
        audiomanage = GameObject.FindGameObjectWithTag("audio");
        if (AudioManager.stopMusic == false)
        {
            audiomanage.GetComponent<AudioManager>().ResumeOnce();
        }
        else 
        {
            audiomanage.GetComponent<AudioManager>().StopOnce();
        }
    }
}
