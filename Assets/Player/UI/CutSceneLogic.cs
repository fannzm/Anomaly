using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutSceneLogic : MonoBehaviour
{
    GameObject Player;
    GameObject Rooms;

    GameObject CutSceneCanvas;

    VideoPlayer videoPlayer;

    [Header("Video Clips")]
    public VideoClip GetNewAi;
    public VideoClip DeleteAi;
    public VideoClip PackageAi;

    float videoTime;

    void Start()
    {
        Player = GameObject.Find("Player");
        Rooms = GameObject.Find("Rooms");
        CutSceneCanvas = GameObject.Find("CutSceneCanvas");
        videoPlayer = GameObject.Find("VideoPlayer").GetComponent<VideoPlayer>();

        CutSceneCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void PlayGetAi()
    {
        PauseGame();
        videoPlayer.clip = GetNewAi;        
        videoPlayer.Play();
        videoTime = (float)videoPlayer.length;
        Invoke("UnPauseGame", videoTime);

    }
    public void PlayDestroyAi()
    {
        PauseGame();
        videoPlayer.clip = DeleteAi;
        videoPlayer.Play();
        videoTime = (float)videoPlayer.length;
        Invoke("PlayGetAi", videoTime);
    }
    public void PlayPackageAi()
    {
        PauseGame();
        videoPlayer.clip = PackageAi;
        videoPlayer.Play();
        videoTime = (float)videoPlayer.length;
        Invoke("PlayGetAi", videoTime);
    }


    public void PauseGame()
    {
        CutSceneCanvas.SetActive(true);
        Player.SetActive(false);
        Rooms.SetActive(false);
    }

    public void UnPauseGame()
    {
        CutSceneCanvas.SetActive(false);
        Player.SetActive(true);
        Rooms.SetActive(true);
    }



    public void showScoreScreen()
    {


    }



}
