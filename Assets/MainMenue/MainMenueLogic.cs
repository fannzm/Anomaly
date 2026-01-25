using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenueLogic : MonoBehaviour
{
    VideoPlayer videoPlayer;
    public VideoClip GetNewAi;
    float videoTime;

    public GameObject MainScreenCanva;
    public GameObject ControlsCanva;
    public GameObject IntroCanva;
    public GameObject CreditsCanva;

    void Start()
    {
        MainScreenCanva.SetActive(true);
        ControlsCanva.SetActive(false);
        IntroCanva.SetActive(false);
        CreditsCanva.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StarGame()
    {

        MainScreenCanva.SetActive(false);
        IntroCanva.SetActive(true);
        videoPlayer = GameObject.Find("VideoPlayer").GetComponent<VideoPlayer>();
        videoPlayer.clip = GetNewAi;
        videoPlayer.Play();
        videoTime = (float)videoPlayer.length;
        Invoke("LoadMainGame", videoTime);

    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OpenControls()
    {
        ControlsCanva.SetActive(true);
    }
    public void CloseControls()
    {
        ControlsCanva.SetActive(false);
    }
    public void OpenCredits()
    {
        CreditsCanva.SetActive(true);
    }

    public void CloseCredits()
    {
        CreditsCanva.SetActive(false);
    }



    public void Quit()
    {
        Application.Quit();
    }







}
