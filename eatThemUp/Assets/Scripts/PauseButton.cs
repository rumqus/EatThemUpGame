using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void PauseSound() 
    {
        Actions.SoundPause();
        AudioManager.stopMusic = !AudioManager.stopMusic;
    }
}
