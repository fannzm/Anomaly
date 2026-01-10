using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int winScore = 8;
    public PlayerProt playerScript;

    public void CorrectChoice()
    {
        score ++;

        if(score >= winScore)
        {
            WinGame();
        }

        else
        {
            Debug.Log("Score: " + score);
            playerScript.TeleportToRoom(score + 1);
        }
    }

    public void WrongChoice()
    {
        score = 0;
        Debug.Log("Score reset to 0");
        playerScript.TeleportToRoom(1);

    }

    void WinGame()
    {
        Debug.Log("You Win!");
    }

    public void GenerateNewCode(RoomState room)
    {
        int code = Random.Range(1000, 9999);
        room.roomCode = code.ToString();

        if(room.codeDisplay != null)
        {
            room.codeDisplay.text = room.roomCode;
        }
    }
}
