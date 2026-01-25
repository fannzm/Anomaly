using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    public GameObject EscapeMenuCanvas;
    public GameObject ControlsCanvas;
    public string mainMenuSceneName = "MainMenue";

    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        EscapeMenuCanvas.SetActive(false);
        ControlsCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ControlsCanvas != null && ControlsCanvas.activeSelf)
            {
                CloseControls();
            }
            else
            {
                TogglePauseGame();
            }
        }
    }

    public void TogglePauseGame()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            EscapeMenuCanvas.SetActive(true);
            Time.timeScale = 0f; 

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            EscapeMenuCanvas.SetActive(false);
            ControlsCanvas.SetActive(false);

            Time.timeScale = 1f;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void BackToShift()
    {
        TogglePauseGame();
    }

    public void OpenControls()
    {
        EscapeMenuCanvas.SetActive(false);
        ControlsCanvas.SetActive(true);
    }

    public void CloseControls()
    {
        ControlsCanvas.SetActive(false);
        EscapeMenuCanvas.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        isPaused = false;
        
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
