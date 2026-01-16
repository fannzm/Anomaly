using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Collections;
using UnityEditor.PackageManager;

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
    public Image inputFieldImage;

    [Header("Feedback Settings")]
    public Color error = Color.red;
    public Color normalColor = Color.white;
    public AudioSource audioSource;
    public AudioClip wrongCodeSound;

    public Player playerScript;

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
        inputFieldImage.color = normalColor;
    }
    public void OnCodeEntered()
    {
        if (currentRoom == null) return;

        if(codeInputField.text.Length == 4)
        {
            if (codeInputField.text == currentRoom.roomCode)
            {
                StartCoroutine(FlashSuccess());
            }
            else
            {
                StartCoroutine(FlashError());
            }   
        }
    }

    IEnumerator FlashSuccess()
    {

        inputFieldImage.color = Color.green;

        yield return new WaitForSeconds(1.0f);
        
        inputFieldImage.color = normalColor;

        UnlockTablet();
    }

    IEnumerator FlashError()
    {
        audioSource.PlayOneShot(wrongCodeSound);
        inputFieldImage.color = error;

        for (int i = 0; i < 5; i++)
        {
            inputFieldImage.color = error;
            yield return new WaitForSeconds(0.1f);

            inputFieldImage.color = normalColor;
            yield return new WaitForSeconds(0.1f);
        }
        inputFieldImage.color = normalColor;
        codeInputField.text = "";
        codeInputField.ActivateInputField();
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
        
        playerScript.CloseTablet();
    }
}