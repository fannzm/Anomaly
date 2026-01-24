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
   


    void Start()
    {
        MainScreenCanva.SetActive(true);
       
        videoPlayer = GameObject.Find("VideoPlayer").GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StarGame()
    {

        MainScreenCanva.SetActive(false);
        
        videoPlayer.clip = GetNewAi;
        videoPlayer.Play();
        videoTime = (float)videoPlayer.length;
        Invoke("LoadMainGame", videoTime);

    }

    public void LoadMainGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Controls()
    {

    }
    public void Quit()
    {
        Application.Quit();
    }







}
