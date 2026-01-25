using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    public int winScore = 8;
    public int score = 0;

    [Header("References")]
    public RoomSpawner roomSpawner;
    public TabletUI tabletUI;



    // Next Room 
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }


    public void CorrectChoice()
    {
        score++;
        Debug.Log("Correct! Current Score: " + score);
        tabletUI.UpdateScoreDisplay(score);
        roomSpawner.RemoveCurrentRoom();

        if (score >= winScore)
        {
            WinGame();
        }
        else
        {
            roomSpawner.SpawnNext();
        }
    }

    // Reset
    public void WrongChoice()
    {
        score = 0;
        Debug.Log("Wrong Choice! Score reset to 0.");

        tabletUI.UpdateScoreDisplay(score);
        roomSpawner.ResetFullPool();
        roomSpawner.ResetProbabilities();
        roomSpawner.SpawnMasterRoom();
    }

    // Win Game
    private void WinGame()
    {
        Debug.Log("yay you win!");
        SceneManager.LoadScene("EndScene");
    }

    // Generates a random 4-digit code
    public void GenerateNewCode(RoomState room)
    {
        int code = Random.Range(1000, 9999);
        room.roomCode = code.ToString();

        if (room.codeDisplay != null)
        {
            room.codeDisplay.text = room.roomCode;
        }
    }
}