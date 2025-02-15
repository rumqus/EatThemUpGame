using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    //[SerializeField] private GameObject startButton;
    //[SerializeField] private GameObject UIpanel;
    //[SerializeField] private GameObject soundButton;
    //[SerializeField] private GameObject pauseButton;
    //[SerializeField] private GameObject unPauseButton;
      [SerializeField] private Animator transAnimator;
      [SerializeField] private float transTime;

    private void Start()
    {
        transAnimator.speed = 0;
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

}
