using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TabletUI : MonoBehaviour
{
    public GameManager gameManager;
    public RoomState currentRoom;
    
    public PlayerProt playerScript;

    public GameObject lockScreenPanel;
    public GameObject submissionPanel;
    public TMP_InputField codeInputField;
    public Toggle AnomalyToggle;

    // Start is called before the first frame update
    void Start()
    {
        ShowLockScreen();
    }

    public void ShowLockScreen()
    {
        lockScreenPanel.SetActive(true);
        submissionPanel.SetActive(false);
        codeInputField.text = "";
        AnomalyToggle.isOn = false;
    }

    public void OnCodeEntered()
    {
        if(codeInputField.text == currentRoom.roomCode)
        {
            UnlockTablet();
        }
    }

    public void UnlockTablet()
    {
        lockScreenPanel.SetActive(false);
        submissionPanel.SetActive(true);
    }

    public void SubmitChoice()
    {
        if(AnomalyToggle.isOn == currentRoom.hasAnomaly)
        {
            gameManager.CorrectChoice();
        }
        else
        {
            gameManager.WrongChoice();
        }

        ShowLockScreen();
      //  playerScript.CloseTablet();
    }
}
