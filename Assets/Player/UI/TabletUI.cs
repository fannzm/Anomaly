using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TabletUI : MonoBehaviour
{
    public GameManager gameManager;
    public RoomState currentRoom;

    [Header("Panels")]
    public GameObject lockScreenPanel;
    public GameObject submissionPanel;

    [Header("Components")]
    public TMP_InputField codeInputField;
    public Toggle anomalyToggle;

    void Start()
    {
        ShowLockScreen();
    }

    public void ShowLockScreen()
    {
        lockScreenPanel.SetActive(true);
        submissionPanel.SetActive(false);
        codeInputField.text = "";
        anomalyToggle.isOn = false;
    }
    public void OnCodeEntered()
    {
        if (currentRoom == null) return;

        if (codeInputField.text == currentRoom.roomCode)
        {
            Debug.Log("Tablet: Correct code entered.");
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
        if (currentRoom == null) return;

        bool playerGuessedAnomaly = anomalyToggle.isOn;

        if (playerGuessedAnomaly == currentRoom.hasAnomaly)
        {
            gameManager.CorrectChoice();
        }
        else
        {
            gameManager.WrongChoice();
        }

        ShowLockScreen();
    }
}