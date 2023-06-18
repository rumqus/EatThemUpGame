using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    //[SerializeField] private GameObject startButton;
    [SerializeField] private GameObject UIpanel;
    //[SerializeField] private GameObject soundButton;
    //[SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject unPauseButton;


    private bool reloaded;    
    private bool sound;

    private void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame() 
    {
       
    }

    public void Pause() 
    {
        
    }

    public void UnPause() 
    {
 
    }

    public void soundOnOFF(bool check) 
    {
        if (check == true)
        {
            check = false;
            // отрубаем звук
        }
        else 
        {
            // врубаем звук
        }

    }

    private void reloadScene() 
    {
        
    }


}
