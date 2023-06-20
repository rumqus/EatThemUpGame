using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    //[SerializeField] private GameObject startButton;
    [SerializeField] private GameObject UIpanel;
    [SerializeField] private float transTime;
    [SerializeField] private GameObject pauseText;
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private Button continueButton;
    //[SerializeField] private GameObject soundButton;
    //[SerializeField] private GameObject pauseButton;
    //[SerializeField] private GameObject unPauseButton;
    
    [SerializeField] private Animator transAnimator;

    private void Awake()
    {
        transAnimator.speed = 0;
    }

    private void OnEnable()
    {
        Actions.EndGame += EndGame;
    }

    private void OnDisable()
    {
        Actions.EndGame -= EndGame;
    }


    private void Start()
    {
        UIpanel.SetActive(false);
    }

    /// <summary>
    /// Loading Scene
    /// </summary>
    /// <param name="index"></param>
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

    /// <summary>
    /// Pause Game
    /// </summary>
    public void Pause() 
    {
        UIpanel.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Unpause Game
    /// </summary>
    public void UnPause() 
    {
        UIpanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void EndGame() 
    {
        pauseText.SetActive(false);
        GameOverText.SetActive(true);
        continueButton.interactable = false;
        Pause();
        
    }

}
