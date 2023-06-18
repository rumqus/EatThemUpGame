using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGame : MonoBehaviour
{
    //[SerializeField] private GameObject startButton;
    [SerializeField] private GameObject UIpanel;
    [SerializeField] private float transTime;
    //[SerializeField] private GameObject soundButton;
    //[SerializeField] private GameObject pauseButton;
    //[SerializeField] private GameObject unPauseButton;
    
    [SerializeField] private Animator transAnimator;

    private void Awake()
    {
        transAnimator.speed = 0;
    }


    private void Start()
    {
        UIpanel.SetActive(false);
    }

    public void LoadScene(int index)
    {

        transAnimator.speed = 1;
        Time.timeScale = 1;
        StartCoroutine(LoadDelay(index));
    }

    IEnumerator LoadDelay(int index)
    {
        transAnimator.Play("FadeEnd");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(index);
    }

    public void Pause() 
    {
        Debug.Log("click");
        UIpanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPause() 
    {
        UIpanel.SetActive(false);
        Time.timeScale = 1;
    }

}
